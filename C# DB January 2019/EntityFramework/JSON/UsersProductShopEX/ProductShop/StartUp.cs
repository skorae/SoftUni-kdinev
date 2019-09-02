namespace ProductShop
{
    using System;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using ProductShop.Data;
    using ProductShop.Models;
    using System.Collections.Generic;
    using ProductShop.Dtos.Export;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var usersJson = File.ReadAllText(@"D:\Coding\C#\EntityFramework\JSON\UsersProductShopEX\ProductShop\Datasets\users.json");
            //var productsJson = File.ReadAllText(@"D:\Coding\C#\EntityFramework\JSON\UsersProductShopEX\ProductShop\Datasets\products.json");
            //var categoriesJson = File.ReadAllText(@"D:\Coding\C#\EntityFramework\JSON\UsersProductShopEX\ProductShop\Datasets\categories.json");
            //var categoryProductssJson = File.ReadAllText(@"D:\Coding\C#\EntityFramework\JSON\UsersProductShopEX\ProductShop\Datasets\categories-products.json");

            //Console.WriteLine(ImportUsers(context, usersJson));
            //Console.WriteLine(ImportProducts(context, productsJson));
            //Console.WriteLine(ImportCategories(context, categoriesJson));
            //Console.WriteLine(ImportCategoryProducts(context, categoryProductssJson));

            Console.WriteLine(GetCategoriesByProductsCount(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson)
                .Where(x => x.LastName != null && x.LastName.Length >= 3)
                .ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson)
                .Where(x => x.Name.Length >= 3)
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(x => x.Name != null && x.Name.Length <= 15 && x.Name.Length >= 3)
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x =>
                new ProductDto()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Seller = x.Seller.FirstName + " " + x.Seller.LastName
                })
                .OrderBy(x => x.Price)
                .ToList();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersSoldProducts = context
                .Users
                .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                    .Where(b => b.Buyer != null)
                    .Select(b => new
                    {
                        name = b.Name,
                        price = b.Price,
                        buyerFirstName = b.Buyer.FirstName,
                        buyerLastName = b.Buyer.LastName
                    })
                    .ToList()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(usersSoldProducts, Formatting.Indented);

            return json;
        }
        
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
                .Select(x => new
                {
                    Category = x.Name,
                    ProductsCount = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Select(p => p.Product.Price).Average().ToString("F"),
                    TotalRevenue = x.CategoryProducts.Select(p => p.Product.Price).Sum().ToString("F")
                })
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(categories, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            return json;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var allUsers = context
                .Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(ps => ps.Buyer != null))
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new
                    {
                        Count = x.ProductsSold
                            .Count(c => c.Buyer != null),

                        Products = x.ProductsSold
                            .Where(c => c.Buyer != null)
                            .Select(c => new
                       {
                           Name = c.Name,
                           Price = c.Price
                       })
                       .ToArray()
                    }
                })
                .ToArray();

            var result = new
            {
                UsersCount = allUsers.Length,
                Users = allUsers
            };

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(result, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }
    }
}