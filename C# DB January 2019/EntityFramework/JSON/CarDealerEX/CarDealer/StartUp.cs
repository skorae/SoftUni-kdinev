namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTO;
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string suppliersJson = File.ReadAllText(@"D:\Coding\C#\EntityFramework\JSON\CarDealerEX\CarDealer\Datasets\suppliers.json");
            //string partsJason = File.ReadAllText(@"D:\Coding\C#\EntityFramework\JSON\CarDealerEX\CarDealer\Datasets\parts.json");
            //string carsJason = File.ReadAllText(@"D:\Coding\C#\EntityFramework\JSON\CarDealerEX\CarDealer\Datasets\cars.json");
            //string customersJason = File.ReadAllText(@"D:\Coding\C#\EntityFramework\JSON\CarDealerEX\CarDealer\Datasets\customers.json");
            //string salesJason = File.ReadAllText(@"D:\Coding\C#\EntityFramework\JSON\CarDealerEX\CarDealer\Datasets\sales.json");

            //Console.WriteLine(ImportSuppliers(context, suppliersJson));
            //Console.WriteLine(ImportParts(context, partsJason));
            //Console.WriteLine(ImportCars(context, carsJason));
            //Console.WriteLine(ImportCustomers(context, customersJason));
            //Console.WriteLine(ImportSales(context, salesJason));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson).ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var supplierIds = context.Suppliers.Select(x => x.Id).ToList();

            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson).ToList();

            var validParts = new List<Part>();

            foreach (var p in parts)
            {
                if (!supplierIds.Contains(p.SupplierId))
                {
                    continue;
                }

                validParts.Add(p);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDtos = JsonConvert.DeserializeObject<List<PartCarsDto>>(inputJson);

            var cars = new List<Car>();

            foreach (var carsDto in carsDtos)
            {
                var car = new Car()
                {
                    Make = carsDto.Make,
                    Model = carsDto.Model,
                    TravelledDistance = carsDto.TravelledDistance
                };
                cars.Add(car);

                var parts = carsDto.PartsId.ToList();
                var allParts = new List<PartCar>();

                foreach (var part in parts.Distinct())
                {
                    var partCar = new PartCar()
                    {
                        Car = car,
                        PartId = part
                    };
                    car.PartCars.Add(partCar);
                }
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson).ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson).ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(c => new OrderedCustomersDto
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(x => x.Make == "Toyota")
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },

                    parts = c.PartCars
                    .Select(x => new
                    {
                        Name = x.Part.Name,
                        Price = x.Part.Price.ToString("F")
                    })
                    .ToList()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });

            return json;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(x => x.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(a => a.SpentMoney)
                .ThenBy(a => a.BoughtCars)
                .ToList();

            var json = JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            return json;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("F"),
                    price = $"{x.Car.PartCars.Sum(c => c.Part.Price):f2}",
                    priceWithDiscount = $"{x.Car.PartCars.Sum(y => y.Part.Price) - (x.Car.PartCars.Sum(y => y.Part.Price) * (x.Discount / 100)):F2}"
                })
                .Take(10)
                .ToList();

            var json = JsonConvert.SerializeObject(sales, new JsonSerializerSettings()
                 {
                     NullValueHandling = NullValueHandling.Ignore,
                     Formatting = Formatting.Indented
                 });

            return json;
        }
    }
}