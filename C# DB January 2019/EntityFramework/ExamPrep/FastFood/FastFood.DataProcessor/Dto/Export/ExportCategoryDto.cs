namespace FastFood.DataProcessor.Dto.Export
{
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class ExportCategoryDto
    {
        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public ExportItemDto MostPopularItem { get; set; }
    }

    public class ExportItemDto
    {
        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public decimal TotalMade { get; set; }

        [XmlElement]
        public int TimesSold { get; set; }
    }
}
