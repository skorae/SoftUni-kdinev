namespace PetClinic.DataProcessor.Dto.Export
{
    using System;
    using System.Xml.Serialization;

    [XmlType("Procedure")]
    public class ExportProcedureDto
    {
        [XmlElement("Passport")]
        public string PassportNumber { get; set; }

        [XmlElement("OwnerNumber")]
        public string OwnerPhoneNumber { get; set; }

        [XmlElement("DateTime")]
        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public ExportAnimalAidsDto[] AnimalAids { get; set; }

        [XmlElement("TotalPrice")]
        public decimal TotalPrice { get; set; }
    }

    [XmlType("AnimalAid")]
    public class ExportAnimalAidsDto
    {
        [XmlElement("Name")]
        public string AidName { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}