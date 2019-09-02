namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
                .Prisoners
                .Select(x => new Rootobject
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(c => new Officer
                    {
                        OfficerName = c.Officer.FullName,
                        Department = c.Officer.Department.Name
                    })
                    .OrderBy(c => c.OfficerName)
                    .ToArray(),
                    TotalOfficerSalary = Math.Round(x.PrisonerOfficers.Sum(f => f.Officer.Salary),2)
                })
                .Where(x => ids.Contains(x.Id))
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            var json = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var sb = new StringBuilder();
            var names = prisonersNames.Split(",");

            var prisonersDto = context
                .Prisoners
                .Where(x => names.Contains(x.FullName))
                .Select(x => new ExportPrisonerInboxDto
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = x.Mails
                        .Select(c => new EmportMessageDto
                        {
                            Description = IncriptMessage(c.Description)
                        })
                        .ToArray()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportPrisonerInboxDto[]), new XmlRootAttribute("Prisoners"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            serializer.Serialize(new StringWriter(sb), prisonersDto,namespaces);

            return sb.ToString().Trim();
        }

        private static string IncriptMessage(string description)
        {
            var sb = new StringBuilder();

            for (int i = description.Length - 1; i >= 0; i--)
            {
                sb.Append(description[i]);
            }

            return sb.ToString().Trim();
        }
    }
}