namespace VaporStore.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Purchase")]
    public class PurchaseDto
    {
        [Required]
        [XmlAttribute("title")]
        public string GameTitle { get; set; }

        [XmlElement("Type")]
        public string PurchaseType { get; set; }

        [Required]
        [XmlElement("Key")]
        [RegularExpression("^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$")]
        public string ProductKey { get; set; }

        [Required]
        [XmlElement("Card")]
        [RegularExpression("^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
        public string CardNumber { get; set; }

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }
    }
}
