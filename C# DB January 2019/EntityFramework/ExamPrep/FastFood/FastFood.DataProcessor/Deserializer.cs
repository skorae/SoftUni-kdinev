using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using FastFood.Models.Enums;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
            var sb = new StringBuilder();
            var employees = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            var validEmployees = new List<Employee>();

            foreach (var emp in employees)
            {
                var isValid = IsValid(emp);

                if (!isValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var position = GetPosition(context, emp.Position);

                var employee = new Employee()
                {
                    Name = emp.Name,
                    Age = emp.Age,
                    Position = position
                };

                validEmployees.Add(employee);
                sb.AppendLine(string.Format(SuccessMessage, employee.Name));
            }

            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            var result = sb.ToString().Trim();

            return result;
		}
        
        public static string ImportItems(FastFoodDbContext context, string jsonString)
		{
            var allItems = JsonConvert.DeserializeObject<ImportItemDto[]>(jsonString);
            var sb = new StringBuilder();

            var validItems = new List<Item>();

            foreach (var dto in allItems)
            {
                var isValid = IsValid(dto);

                if (!isValid || validItems.Any(x => x.Name == dto.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var category = GetCategory(context, dto.Category);

                var item = new Item()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Category = category
                };

                validItems.Add(item);
                sb.AppendLine(string.Format(SuccessMessage, item.Name));
            }

            context.Items.AddRange(validItems);
            context.SaveChanges();

            var result = sb.ToString().Trim();

            return result;
		}

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
		{
            var serializer = new XmlSerializer(typeof(ImportOrdersDto[]), new XmlRootAttribute("Orders"));

            var ordersDto = (ImportOrdersDto[])serializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();

            var validOrders = new List<Order>();

            var employees = context.Employees.ToHashSet();
            var items = context.Items.ToHashSet();

            foreach (var dto in ordersDto)
            {

                var isValid = IsValid(dto) &&
                    dto.Items.All(x => IsValid(x)) &&
                    employees.Any(x => x.Name == dto.EmployeeName) &&
                    dto.Items.All(x => items.Any(i => i.Name == x.ItemName));

                if (!isValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var order = new Order()
                {
                    Employee = employees.First(x => x.Name == dto.EmployeeName),
                    Customer = dto.Customer,
                    DateTime = DateTime.ParseExact(dto.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Type = Enum.TryParse<OrderType>(dto.Type, out OrderType type) ? type : 0,
                    OrderItems = dto.Items.Select(x => new OrderItem()
                    {
                        Item = items.FirstOrDefault(i => i.Name == x.ItemName),
                        Quantity = x.Quantity
                    }).ToList()
                };

                validOrders.Add(order);
                sb.AppendLine($"Order for {order.Customer} on {order.DateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} added");
            }

            context.Orders.AddRange(validOrders);
            context.SaveChanges();

            var result = sb.ToString().Trim();

            return result;
		}

        private static Category GetCategory(FastFoodDbContext context, string categoryName)
        {
            var category = context.Categories.FirstOrDefault(x => x.Name == categoryName);

            if (category != null)
            {
                return category;
            }

            category = new Category()
            {
                Name = categoryName
            };

            context.Categories.Add(category);
            context.SaveChanges();

            return category;
        }
        
        private static Position GetPosition(FastFoodDbContext context, string positionName)
        {
            var position = context.Positions.FirstOrDefault(x => x.Name == positionName);

            if (position != null)
            {
                return position;
            }

            position = new Position()
            {
                Name = positionName
            };

            context.Positions.Add(position);
            context.SaveChanges();

            return position;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var valdiationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, valdiationResults, true);

            return isValid;
        }
	}
}