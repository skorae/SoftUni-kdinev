namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using ProductShop.Data;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;

    public class StartUp
    {

        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string usersXml = File.ReadAllText(@"D:\Coding\C#\EntityFramework\HML\ProductShop_EX\ProductShop\Datasets\users.xml");
            //string productsXml = File.ReadAllText(@"D:\Coding\C#\EntityFramework\HML\ProductShop_EX\ProductShop\Datasets\products.xml");
            //string categoriesXml = File.ReadAllText(@"D:\Coding\C#\EntityFramework\HML\ProductShop_EX\ProductShop\Datasets\categories.xml");
            //string categoriesProductsXml = File.ReadAllText(@"D:\Coding\C#\EntityFramework\HML\ProductShop_EX\ProductShop\Datasets\categories-products.xml");

            //Console.WriteLine(ImportUsers(context, usersXml));
            //Console.WriteLine(ImportProducts(context, productsXml));
            //Console.WriteLine(ImportCategories(context, categoriesXml));
            //Console.WriteLine(ImportCategoryProducts(context, categoriesProductsXml));

            Console.WriteLine(GetUsersWithProducts(context));
        }
        
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            var usersDto = (ImportUserDto[])serializer.Deserialize(new StringReader(inputXml));

            List<User> validUsers = new List<User>();

            foreach (var userDto in usersDto)
            {
                var user = new User()
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Age = userDto.Age
                };
                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            var productsDto = (ImportProductDto[])serializer.Deserialize(new StringReader(inputXml));

            var validProducts = new List<Product>();

            foreach (var productDto in productsDto)
            {
                var product = new Product()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    SellerId = productDto.SellerId,
                    BuyerId = productDto.BuyerId
                };
                validProducts.Add(product);
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

            var categoriesDto = (ImportCategoryDto[])serializer.Deserialize(new StringReader(inputXml));

            var validCategories = new List<Category>();

            foreach (var categoryDto in categoriesDto)
            {
                var category = new Category()
                {
                    Name = categoryDto.Name
                };
                validCategories.Add(category);
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

            var categiesProductsDto = (ImportCategoryProductDto[])serializer.Deserialize(new StringReader(inputXml));

            var validCategoriesProducts = new List<CategoryProduct>();

            foreach (var cpDto in categiesProductsDto)
            {
                var cp = new CategoryProduct()
                {
                    CategoryId = cpDto.CategoryId,
                    ProductId = cpDto.ProductId
                };
                validCategoriesProducts.Add(cp);
            }

            context.CategoryProducts.AddRange(validCategoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoriesProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ExportProductInRange()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportProductInRange[]), new XmlRootAttribute("Products"));

            StringBuilder builder = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            serializer.Serialize(new StringWriter(builder), products, namespaces);

            return builder.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var products = context
                .Users
                .Where(x => x.ProductsSold.Count > 0)
                .Select(x => new ExportSoldProductDto()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(c => new ProductDto()
                    {
                        Name = c.Name,
                        Price = c.Price
                    })
                    .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportSoldProductDto[]), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            serializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().Trim();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(x => new ExportCategoriesByProductsCount()
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            var sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCategoriesByProductsCount[]), new XmlRootAttribute("Categories"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            serializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().Trim();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = new ExportUserWithCategoryDto()
            {
                Count = context
                    .Users
                    .Count(x => x.ProductsSold.Any()),

                Users = context
                    .Users
                    .Where(x => x.ProductsSold.Any())
                    .Select(x => new UserDto()
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Age = x.Age,
                        SoldProducts = new SoldProductDto
                        {
                            Count = x.ProductsSold.Count,
                            Products = x.ProductsSold.Select(d => new ProductDto
                            {
                                Name = d.Name,
                                Price = d.Price
                            })
                            .OrderByDescending(d => d.Price)
                            .ToArray()
                        }
                    })
                    .OrderByDescending(x => x.SoldProducts.Count)
                    .Take(10)
                    .ToArray()
            };

            XmlSerializer serializer = new XmlSerializer(typeof(ExportUserWithCategoryDto));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            serializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().Trim();
        }
    }
}