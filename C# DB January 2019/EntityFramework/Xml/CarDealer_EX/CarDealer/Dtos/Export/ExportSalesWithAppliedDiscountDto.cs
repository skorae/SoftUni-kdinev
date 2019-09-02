﻿namespace CarDealer.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("sale")]
    public class ExportSalesWithAppliedDiscountDto
    {
        [XmlElement("car")]
        public ExportCarAttributeDto Car { get; set; }

        [XmlElement("discount")]
        public decimal Discoount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public decimal PriceWithDiscount { get; set; }
    }
}

