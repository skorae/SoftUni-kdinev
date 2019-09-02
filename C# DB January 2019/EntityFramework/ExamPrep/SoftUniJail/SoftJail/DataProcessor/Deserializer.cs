namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var departmentsDto = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            var validDepartments = new List<Department>();

            foreach (var departmentDto in departmentsDto)
            {
                if (!IsValid(departmentDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var department = ValidateDepartment(context, departmentDto);

                var isBreackable = false;

                foreach (var cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        isBreackable = true;
                        break;
                    }

                    var cell = ValidateCell(context, cellDto, department);

                    department.Cells.Add(cell);
                }

                if (isBreackable)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                validDepartments.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.UpdateRange(validDepartments);
            context.SaveChanges();

            var result = sb.ToString().Trim();

            return result;
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var prisonersDto = JsonConvert.DeserializeObject<ImportPrisonersDto[]>(jsonString);

            var validPrisoners = new List<Prisoner>();
            var validMails = new List<Mail>();

            foreach (var prisonerDto in prisonersDto)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var incarcerationDate = TryParceNullableDateTime(prisonerDto.IncarcerationDate);
                
                var releaseDate = TryParceNullableDateTime(prisonerDto.ReleaseDate);

                //var cellId = context.Cells.FirstOrDefault(x => x.Id == prisonerDto.CellId);

                //if (incarcerationDate == null)
                //{
                //    sb.AppendLine("Invalid Data");
                //    continue;
                //}

                //if (cellId == null && prisonerDto.CellId != null)
                //{
                //    sb.AppendLine("Invalid Data");
                //    continue;
                //}

                var prisoner = new Prisoner()
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = (DateTime)incarcerationDate,
                    ReleaseDate = releaseDate,
                    CellId = prisonerDto.CellId
                };

                var isBreackable = false;

                foreach (var mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        isBreackable = true;
                        break;
                    }
                    
                    var mail = new Mail()
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address,
                        Prisoner = prisoner
                    };

                    prisoner.Mails.Add(mail);
                    validMails.Add(mail);
                }

                if (isBreackable)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                validPrisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(validPrisoners);
            context.Mails.AddRange(validMails);
            context.SaveChanges();

            var result = sb.ToString().Trim();

            return result;
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ImportOfficerPrisonerDto[]), new XmlRootAttribute("Officers"));

            var officersDto = (ImportOfficerPrisonerDto[])serializer.Deserialize(new StringReader(xmlString));

            var validOfficers = new List<Officer>();
            var validOfficerPrisones = new List<OfficerPrisoner>();

            foreach (var officerDto in officersDto)
            {
                if (!IsValid(officerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var positionDto = Enum.TryParse<Position>(officerDto.Position, out Position position);
                var weaponDto = Enum.TryParse<Weapon>(officerDto.Weapon, out Weapon weapon);
                
                if (!positionDto || !weaponDto)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var officer = new Officer()
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money,
                    DepartmentId = officerDto.DepartmentId,
                    Weapon = weapon,
                    Position = position
                };

                foreach (var prisonerIdDto in officerDto.Prisoners)
                {
                    var officerPrisoner = new OfficerPrisoner()
                    {
                        Officer = officer,
                        PrisonerId = prisonerIdDto.Id
                    };

                    officer.OfficerPrisoners.Add(officerPrisoner);
                    validOfficerPrisones.Add(officerPrisoner);
                }

                validOfficers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(validOfficers);
            context.OfficersPrisoners.AddRange(validOfficerPrisones);
            context.SaveChanges();

            var result = sb.ToString().Trim();

            return result;
        }

        private static Department ValidateDepartment(SoftJailDbContext context, ImportDepartmentDto departmentDto)
        {
            var department = context.Departments.FirstOrDefault(x => x.Name == departmentDto.Name);

            if (department == null)
            {
                department = new Department()
                {
                    Name = departmentDto.Name
                };
            }
            return department;
        }

        private static Cell ValidateCell(SoftJailDbContext context, ImportCellDto cellDto, Department department)
        {
            var cell = context.Cells.FirstOrDefault(x => x.CellNumber == cellDto.CellNumber);

            if (cell == null)
            {
                cell = new Cell()
                {
                    CellNumber = cellDto.CellNumber,
                    HasWindow = cellDto.HasWindow,
                    Department = department
                };

                context.Cells.Add(cell);
                context.SaveChanges();
            }

            return cell;
        }

        private static DateTime? TryParceNullableDateTime(string releaseDate)
        {
            return DateTime.TryParseExact(releaseDate, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result)
                ?
                (DateTime?)result : null;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}