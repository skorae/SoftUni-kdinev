namespace PetClinic.DataProcessor.Dto.Import
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    [XmlType("Vet")]
    public class ImportVetDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [XmlElement("Profession")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Profession { get; set; }

        [XmlElement("Age")]
        [Required]
        [Range(22, 65)]
        public int Age { get; set; }

        [XmlElement("PhoneNumber")]
        [Required]
        [RegularExpression(@"^0[0-9]{9}$|^\+359[0-9]{9}$")]
        public string PhoneNumber { get; set; }
    }
}