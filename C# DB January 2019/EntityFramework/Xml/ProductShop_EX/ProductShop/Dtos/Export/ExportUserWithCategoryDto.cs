namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlRoot("Users")]
    public class ExportUserWithCategoryDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UserDto[] Users { get; set; }
    }
}
