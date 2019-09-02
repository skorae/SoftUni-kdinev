namespace CarDealer.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("part")]
    public class ExportParAtributeDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public string Price { get; set; }
    }
}
