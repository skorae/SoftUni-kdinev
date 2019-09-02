﻿namespace SoftJail.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Prisoner")]
    public class ExportPrisonerInboxDto
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public EmportMessageDto[] EncryptedMessages { get; set; }
    }

    [XmlType("Message")]
    public class EmportMessageDto
    {
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}
