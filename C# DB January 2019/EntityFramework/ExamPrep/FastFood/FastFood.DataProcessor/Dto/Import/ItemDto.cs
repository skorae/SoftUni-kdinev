namespace FastFood.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Item")]
    public class ItemDto
    {
        [Required]
        [XmlElement("Name")]
        [StringLength(30, MinimumLength = 3)]
        public string ItemName { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}