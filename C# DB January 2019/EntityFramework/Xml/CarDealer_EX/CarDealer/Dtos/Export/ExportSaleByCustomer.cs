namespace CarDealer.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("customer")]
    public class ExportSaleByCustomer
    {
    [XmlAttribute("full-name")]
        public string FullName { get; set; }

    [XmlAttribute("bought-cars")]
        public string BoughtCars { get; set; }

    [XmlAttribute("spent-money")]
        public string SpentMoney { get; set; }
    }
}
