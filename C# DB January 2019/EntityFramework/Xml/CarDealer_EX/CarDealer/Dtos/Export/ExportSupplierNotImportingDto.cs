namespace CarDealer.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("suplier")]
    public class ExportSupplierNotImportingDto
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("parts-count")]
        public string PartsCount { get; set; }
    }
}
