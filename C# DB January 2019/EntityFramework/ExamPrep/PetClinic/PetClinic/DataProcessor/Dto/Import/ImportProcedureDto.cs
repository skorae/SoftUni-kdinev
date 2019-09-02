namespace PetClinic.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Procedure")]
    public class ImportProcedureDto
    {
        [XmlElement("Vet")]
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string VetName { get; set; }

        [XmlElement("Animal")]
        [Required]
        [RegularExpression("^[A-Za-z]{7}[0-9]{3}$")]
        public string AnimalPassportSerialNumber { get; set; }

        [XmlElement("DateTime")]
        [Required]
        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public ImportAidDto[] AnimalAids { get; set; }
    }

    [XmlType("AnimalAid")]
    public class ImportAidDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string AidName { get; set; }
    }
}