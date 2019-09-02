namespace CarDealer
{
    using System;
    using System.IO;
    using CarDealer.Data;
    using System.Xml.Serialization;
    using CarDealer.Dtos.Import;
    using System.Collections.Generic;
    using CarDealer.Models;
    using System.Linq;
    using System.Xml.Linq;
    using CarDealer.Dtos.Export;
    using System.Text;
    using System.Xml;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string suppliersXml = File.ReadAllText(@"D:\Coding\C#\EntityFramework\XML\CarDealer_EX\CarDealer\Datasets\suppliers.xml");
            string partsXml = File.ReadAllText(@"D:\Coding\C#\EntityFramework\XML\CarDealer_EX\CarDealer\Datasets\parts.xml");
            string carsXml = File.ReadAllText(@"D:\Coding\C#\EntityFramework\XML\CarDealer_EX\CarDealer\Datasets\cars.xml");
            string customersXml = File.ReadAllText(@"D:\Coding\C#\EntityFramework\XML\CarDealer_EX\CarDealer\Datasets\customers.xml");
            string salesXml = File.ReadAllText(@"D:\Coding\C#\EntityFramework\XML\CarDealer_EX\CarDealer\Datasets\sales.xml");

            Console.WriteLine(ImportSuppliers(context, suppliersXml));
            Console.WriteLine(ImportParts(context, partsXml));
            Console.WriteLine(ImportCars(context, carsXml));
            Console.WriteLine(ImportCustomers(context, customersXml));
            Console.WriteLine(ImportSales(context, salesXml));

            //Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("Suppliers"));

            var suppliersDto = (ImportSupplierDto[])serializer.Deserialize(new StringReader(inputXml));

            var validSuppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDto)
            {
                var supplier = new Supplier()
                {
                    Name = supplierDto.Name,
                    IsImporter = supplierDto.IsImporter
                };
                validSuppliers.Add(supplier);
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));

            var partsDto = (ImportPartDto[])serializer.Deserialize(new StringReader(inputXml));

            var validParts = new List<Part>();

            foreach (var partDto in partsDto)
            {
                var supplier = context.Suppliers.Find(partDto.SupplierId);

                if (supplier == null)
                {
                    continue;
                }

                var part = new Part()
                {
                    Name = partDto.Name,
                    Price = partDto.Price,
                    Quantity = partDto.Quantity,
                    SupplierId = partDto.SupplierId
                };
                validParts.Add(part);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var carXml = XDocument.Parse(inputXml).Root.Elements();

            var validCars = new List<Car>();
            var partsCars = new List<PartCar>();

            var validParts = context.Parts.Select(x => x.Id);

            foreach (var c in carXml)
            {
                var partIds = new List<int>();

                var car = new Car();
                car.Make = c.Element("make").Value;
                car.Model = c.Element("model").Value;
                car.TravelledDistance = long.Parse(c.Element("TraveledDistance").Value);

                validCars.Add(car);

                foreach (var id in c.Element("parts").Elements().ToList())
                {
                    var partId = int.Parse(id.Attribute("id").Value);

                    if (!validParts.Contains(partId))
                    {
                        continue;
                    }

                    partIds.Add(partId);
                }

                foreach (var id in partIds.Distinct())
                {
                    var partCar = new PartCar();
                    partCar.Car = car;
                    partCar.PartId = id;

                    partsCars.Add(partCar);
                }
            }

            context.Cars.AddRange(validCars);
            context.PartCars.AddRange(partsCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            var cutomersDto = (ImportCustomerDto[])serializer.Deserialize(new StringReader(inputXml));

            var validCustomers = new List<Customer>();

            foreach (var c in cutomersDto)
            {
                var customer = new Customer()
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                };
                validCustomers.Add(customer);
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSalesDto[]), new XmlRootAttribute("Sales"));

            var salesDto = (ImportSalesDto[])serializer.Deserialize(new StringReader(inputXml));

            var validSales = new List<Sale>();

            var cars = context.Cars.Select(x => x.Id);

            foreach (var s in salesDto)
            {
                if (!cars.Contains(s.CarId))
                {
                    continue;
                }

                var sale = new Sale()
                {
                    CarId = s.CarId,
                    CustomerId = s.CustomerId,
                    Discount = s.Discount
                };
                validSales.Add(sale);
            }

            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(x => x.TravelledDistance > 2000000)
                .Select(x => new ExportCarDto()
                {
                    Make = x.Make,
                    Model = x.Model,
                    TraveledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            return Serialzie(cars, rootName: "cars");
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(x => x.Make.ToLower() == "bmw")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new ExportBmwDto()
                {
                    Id = x.Id.ToString(),
                    Model = x.Model,
                    Travelleddistance = x.TravelledDistance.ToString()
                })
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportBmwDto[]));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().Trim();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new ExportSupplierNotImportingDto()
                {
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    PartsCount = x.Parts.Count.ToString()
                })
                .ToArray();

            string rootName = "suppliers";

            return Serialzie(suppliers, rootName);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithPartsDto = context
                .Cars
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Select(x => new ExportCarWithPartsDto
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance.ToString(),

                    Parts = x.PartCars
                        .OrderByDescending(c => c.Part.Price)
                        .Select(c => new ExportParAtributeDto
                        {
                            Name = c.Part.Name,
                            Price = c.Part.Price.ToString()
                        })
                        .ToArray()
                })
                .Take(5)
                .ToArray();

            return Serialzie(carsWithPartsDto, rootName:"cars");
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(x => x.Sales.Any())
                .OrderByDescending(x => x.Sales.Sum(c => c.Car.PartCars.Sum(d => d.Part.Price)))
                .Select(x => new ExportSaleByCustomer()
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count.ToString(),
                    SpentMoney = x.Sales.Sum(c => c.Car.PartCars.Sum(d => d.Part.Price)).ToString("F")
                })
                .ToArray();

            return Serialzie(customers, rootName: "customers");
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Select(x => new ExportSalesWithAppliedDiscountDto
                {
                    Car = new ExportCarAttributeDto
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },

                    Discoount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(c => c.Part.Price),
                    PriceWithDiscount = (x.Car.PartCars.Sum(y => y.Part.Price) - (x.Car.PartCars.Sum(y => y.Part.Price) * x.Discount / 100))
                })
                .ToArray();

            return Serialzie(sales, rootName: "sales");
        }

        private static string Serialzie<T>(T[] dtoArr, string rootName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T[]), new XmlRootAttribute(rootName));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            serializer.Serialize(new StringWriter(sb), dtoArr, namespaces);

            return sb.ToString().Trim();
        }
    }
}