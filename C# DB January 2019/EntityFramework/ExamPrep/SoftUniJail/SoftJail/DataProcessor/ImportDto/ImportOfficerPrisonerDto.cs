namespace SoftJail.DataProcessor.ImportDto
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;
    using SoftJail.Data.Models.Enums;

    [XmlType("Officer")]
    public class ImportOfficerPrisonerDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [XmlElement("Money")]
        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Money { get; set; }

        [XmlElement("Position")]
        [Required]
        public string Position { get; set; }

        [XmlElement("Weapon")]
        [Required]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        [Required]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public PrisonerDto[] Prisoners { get; set; }
    }

    [XmlType("Prisoner")]
    public class PrisonerDto
    {
        [XmlAttribute("id")]
        [Required]
        public int Id { get; set; }
    }
}

