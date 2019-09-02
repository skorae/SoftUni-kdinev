using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Export;
using FastFood.Models.Enums;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace FastFood.DataProcessor
{
    public class Serializer
    {
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {
            var type = Enum.Parse<OrderType>(orderType);

            var employee = context
                .Employees
                .Where(x => x.Name == employeeName)
                .Select(x => new
                {
                    Name = x.Name,
                    Orders = x.Orders
                        .Where(o => o.Type == type)
                        .Select(o => new
                        {
                            Customer = o.Customer,
                            Items = o.OrderItems
                            .Select(i => new
                            {
                                Name = i.Item.Name,
                                Price = i.Item.Price,
                                Quantity = i.Quantity
                            })
                            .ToArray(),
                            TotalPrice = o.OrderItems.Sum(oi => oi.Item.Price * oi.Quantity)
                        })
                        .OrderByDescending(o => o.TotalPrice)
                        .ThenByDescending(o => o.Items.Length)
                        .ToArray(),
                    TotalMade = x.Orders
                        .Where(o => o.Type == type)
                        .Sum(o => o.OrderItems.Sum(oi => oi.Item.Price * oi.Quantity))
                })
                .FirstOrDefault();


            var json = JsonConvert.SerializeObject(employee, Formatting.Indented);

            return json;
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            var sb = new StringBuilder();

            var validCategories = categoriesString.Split(",");

            var categories = context
                .Items
                .Where(x => validCategories.Contains(x.Category.Name))
                .GroupBy(x => x.Category.Name)
                .Select(c => new ExportCategoryDto
                {
                    Name = c.Key,
                    MostPopularItem = c.Select(i => new ExportItemDto
                    {
                        Name = i.Name,
                        TotalMade = i.OrderItems.Sum(oi => oi.Quantity * oi.Item.Price),
                        TimesSold = i.OrderItems.Sum(oi => oi.Quantity)
                    })
                    .OrderByDescending(i => i.TotalMade)
                    .ThenByDescending(i => i.TimesSold)
                    .First()
                })
                .OrderByDescending(dto => dto.MostPopularItem.TotalMade)
                .ThenByDescending(dto => dto.MostPopularItem.TimesSold)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportCategoryDto[]), new XmlRootAttribute("Categories"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            serializer.Serialize(new StringWriter(sb), categories, namespaces);

            var result = sb.ToString().Trim();

            return result;
        }
    }
}