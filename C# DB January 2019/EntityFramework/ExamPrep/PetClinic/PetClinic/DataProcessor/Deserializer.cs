namespace PetClinic.DataProcessor
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using System.Text;
    using PetClinic.DataProcessor.Dto.Import;
    using PetClinic.Models;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.IO;

    public class Deserializer
    {
        private const string errorMessage = "Error: Invalid data.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var animalAids = JsonConvert.DeserializeObject<ImportAnimalAidDto[]>(jsonString);

            foreach (var animalAidDto in animalAids)
            {
                if (!IsValid(animalAidDto))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                var animalAid = new AnimalAid()
                {
                    Name = animalAidDto.Name,
                    Price = animalAidDto.Price
                };

                var isAnimalAidValid = context.AnimalAids.Any(x => x.Name == animalAid.Name);

                if (isAnimalAidValid)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                context.AnimalAids.Add(animalAid);
                context.SaveChanges();

                sb.AppendLine($"Record {animalAid.Name} successfully imported.");
            }

            var result = sb.ToString().Trim();

            return result;
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var animalsDto = JsonConvert.DeserializeObject<ImportAnimalsDto[]>(jsonString);

            var validAnimals = new List<Animal>();

            foreach (var animalDto in animalsDto)
            {
                if (!IsValid(animalDto))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                var animal = new Animal()
                {
                    Name = animalDto.Name,
                    Type = animalDto.Type,
                    Age = animalDto.Age
                };

                var passport = ValidatePassport(context, animalDto.Passport);

                if (passport == null)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                animal.Passport = passport;

                validAnimals.Add(animal);
                sb.AppendLine($"Record {animal.Name} Passport №: {passport.SerialNumber} successfully imported.");
            }

            context.Animals.AddRange(validAnimals);
            context.SaveChanges();

            var result = sb.ToString().Trim();

            return result;
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportVetDto[]), new XmlRootAttribute("Vets"));
            var sb = new StringBuilder();

            var vetsDtp = (ImportVetDto[])serializer.Deserialize(new StringReader(xmlString));
            var validVets = new List<Vet>();

            foreach (var vetDto in vetsDtp)
            {
                if (!IsValid(vetDto))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                var vet = new Vet()
                {
                    Name = vetDto.Name,
                    PhoneNumber = vetDto.PhoneNumber,
                    Profession = vetDto.Profession,
                    Age = vetDto.Age
                };

                var isPhoneExisting = validVets.Any(x => x.PhoneNumber == vet.PhoneNumber);

                if (isPhoneExisting)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                validVets.Add(vet);
                sb.AppendLine($"Record {vet.Name} successfully imported.");
            }

            context.Vets.AddRange(validVets);
            context.SaveChanges();

            var result = sb.ToString().Trim();

            return result;
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportProcedureDto[]), new XmlRootAttribute("Procedures"));
            var sb = new StringBuilder();

            var proceduresDto = (ImportProcedureDto[])serializer.Deserialize(new StringReader(xmlString));

            var validProcedures = new List<Procedure>();
            var validProcedureAnimalAids = new List<ProcedureAnimalAid>();
            
            foreach (var procedureDto in proceduresDto)
            {
                if (!IsValid(procedureDto))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                var vet = (Vet)GetEntity<Vet>(context, procedureDto.VetName);

                var animal = (Animal)GetEntity<Animal>(context, procedureDto.AnimalPassportSerialNumber);

                if (vet == null || animal == null)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                var procedure = new Procedure()
                {
                    Vet = vet,
                    Animal = animal,
                    DateTime = DateTime.ParseExact(procedureDto.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture)
                };

                var isBreackable = false;

                var validAnimalAids = new List<AnimalAid>();

                foreach (var animalAidDto in procedureDto.AnimalAids)
                {
                    var animalAid = (AnimalAid)GetEntity<AnimalAid>(context, animalAidDto.AidName);

                    if (!IsValid(animalAidDto.AidName) ||
                        animalAid == null ||
                        validAnimalAids.Any(x => x.Name == animalAidDto.AidName))
                    {
                        isBreackable = true;
                        sb.AppendLine(errorMessage);
                        break;
                    }

                    validAnimalAids.Add(animalAid);
                }

                if (isBreackable)
                {
                    continue;
                }

                foreach (var animalAid in validAnimalAids)
                {
                    var procedureAnimalAid = new ProcedureAnimalAid()
                    {
                        Procedure = procedure,
                        AnimalAid = animalAid
                    };

                    procedure.ProcedureAnimalAids.Add(procedureAnimalAid);
                    validProcedureAnimalAids.Add(procedureAnimalAid);
                }

                validProcedures.Add(procedure);
                sb.AppendLine($"Record successfully imported.");
            }

            context.Procedures.AddRange(validProcedures);
            context.ProceduresAnimalAids.AddRange(validProcedureAnimalAids);
            context.SaveChanges();

            var result = sb.ToString().Trim();

            return result;
        }

        private static object GetEntity<T>(PetClinicContext context, string param)
        {
            object element;

            switch (typeof(T).Name)
            {
                case "Vet":
                    element = context.Vets.FirstOrDefault(x => x.Name == param);
                    break;
                case "Animal":
                    element = context.Animals.FirstOrDefault(x => x.PassportSerialNumber == param);
                    break;
                case "AnimalAid":
                    element = context.AnimalAids.FirstOrDefault(x => x.Name == param);
                    break;
                default:
                    return null;
            }

            return element;
        }

        private static Passport ValidatePassport(PetClinicContext context, ImportPassportDto passportDto)
        {
            if (!IsValid(passportDto))
            {
                return null;
            }

            var isValidEntry = context.Passports.Any(x => x.SerialNumber == passportDto.SerialNumber);

            if (isValidEntry)
            {
                return null;
            }

            var passport = new Passport()
            {
                SerialNumber = passportDto.SerialNumber,
                OwnerName = passportDto.OwnerName,
                OwnerPhoneNumber = passportDto.OwnerPhoneNumber,
                RegistrationDate = DateTime.ParseExact(passportDto.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)
            };
            
            context.Passports.Add(passport);
            context.SaveChanges();

            return passport;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);

            return isValid;
        }
    }
}