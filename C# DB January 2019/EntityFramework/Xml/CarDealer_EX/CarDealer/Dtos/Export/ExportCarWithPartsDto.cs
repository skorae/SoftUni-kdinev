namespace CarDealer.Dtos.Export
{
    using System.Xml.Serialization;

   [XmlType("car")]
    public class ExportCarWithPartsDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public string TravelledDistance { get; set; }

        [XmlArray("parts")]
        public ExportParAtributeDto[] Parts { get; set; }
    }
}
