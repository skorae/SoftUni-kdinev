namespace PetClinic.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.Dto.Export;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context
                .Animals
                .Where(x => x.Passport.OwnerPhoneNumber == phoneNumber)
                .Select(x => new
                {
                    OwnerName = x.Passport.OwnerName,
                    AnimalName = x.Name,
                    Age = x.Age,
                    SerialNumber = x.Passport.SerialNumber,
                    RegisteredOn = x.Passport.RegistrationDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
                })
                .OrderBy(x => x.Age)
                .ThenBy(x => x.SerialNumber)
                .ToArray();

            var json = JsonConvert.SerializeObject(animals, Formatting.Indented);

            return json;
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedures = context
                .Procedures
                .OrderBy(x => x.DateTime)
                .Select(x => new ExportProcedureDto
                {
                    PassportNumber = x.Animal.PassportSerialNumber,
                    OwnerPhoneNumber = x.Animal.Passport.OwnerPhoneNumber,
                    DateTime = x.DateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    AnimalAids = x.ProcedureAnimalAids
                        .Select(c => new ExportAnimalAidsDto
                        {
                            AidName = c.AnimalAid.Name,
                            Price = c.AnimalAid.Price
                        })
                        .ToArray(),
                    TotalPrice = x.ProcedureAnimalAids.Sum(f => f.AnimalAid.Price)
                })
                .OrderBy(v => v.PassportNumber)
                .ToArray();
                
            var sb = new StringBuilder();
            var serializer = new XmlSerializer(typeof(ExportProcedureDto[]), new XmlRootAttribute("Procedures"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            serializer.Serialize(new StringWriter(sb), procedures, namespaces);

            var result = sb.ToString().Trim();

            return result;
        }
    }
}
