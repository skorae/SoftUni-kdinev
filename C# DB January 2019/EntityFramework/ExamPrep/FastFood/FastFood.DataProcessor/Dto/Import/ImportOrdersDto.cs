namespace FastFood.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Order")]
    public class ImportOrdersDto
    {
        [Required]
        public string Customer { get; set; }

        [Required]
        [XmlElement("Employee")]
        [StringLength(30,MinimumLength =3)]
        public string EmployeeName { get; set; }

        [Required]
        public string DateTime { get; set; }

        [Required]
        public string Type { get; set; }

        [XmlArray("Items")]
        public ItemDto[] Items { get; set; }
    }
}