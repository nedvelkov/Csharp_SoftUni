using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DataTransferObjects;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var productShopContext = new ProductShopContext();
            /*
              productShopContext.Database.EnsureDeleted();
              productShopContext.Database.EnsureCreated();
                                   
            string userJson = File.ReadAllText("../../../Datasets/users.json");
            string produtsJson = File.ReadAllText("../../../Datasets/products.json");
            string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");
            ImportUsers(productShopContext, userJson);
            ImportProducts(productShopContext, produtsJson);
            ImportCategories(productShopContext, categoriesJson);
            ImportCategoryProducts(productShopContext, inputJson);
            
            */
            Console.WriteLine(GetUsersWithProducts(productShopContext));


        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var dtoUsers = JsonConvert.DeserializeObject<List<UserInputModel>>(inputJson);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            IMapper mapper = config.CreateMapper();

            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);

            ;
            context.SaveChanges();


            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var dtoProducts = JsonConvert.DeserializeObject<List<ProdutcInputModel>>(inputJson);

            IMapper mapper = InitializeMapper();

            ;
            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(products);


            ;
            context.SaveChanges();


            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var dtoCategories = JsonConvert.DeserializeObject<List<CategoryInputModel>>(inputJson).Where(n => n.Name != null);

            IMapper mapper = InitializeMapper();

            ;
            var categories = mapper.Map<IEnumerable<Category>>(dtoCategories);

            context.Categories.AddRange(categories);


            ;
            context.SaveChanges();


            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var dtoCategoryProductInputs = JsonConvert.DeserializeObject<List<CategoryProductInputModel>>(inputJson);

            IMapper mapper = InitializeMapper();

            ;
            var categories = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoryProductInputs);

            context.CategoryProducts.AddRange(categories);


            ;
            context.SaveChanges();


            return $"Successfully imported {categories.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var produtcs = context.Products
                    .Where(p => p.Price >= 500 && p.Price <= 1000)
                    .Include(x => x.Seller)
                    .Select(x => new
                    {
                        name = x.Name,
                        price = x.Price,
                        seller = x.Seller.FirstName + " " + x.Seller.LastName

                    })
                    .OrderBy(x => x.price)
                    .ToList();

            var result = JsonConvert.SerializeObject(produtcs, Formatting.Indented);
            //   File.WriteAllText("export",result);

            return result;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(x => x.ProductsSold.Count() >= 1)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold.Where(b => b.BuyerId != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                })
                .OrderBy(f => f.lastName).ThenBy(n => n.firstName)
                .ToList();

            var result = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);

            return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var productCount = context.Categories
                .OrderByDescending(x => x.CategoryProducts.Count())
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count(),
                    averagePrice = $"{ x.CategoryProducts.Average(a => a.Product.Price):f2}",
                    totalRevenue = $"{ x.CategoryProducts.Sum(a => a.Product.Price):f2}"
                })
                .ToList();

            var result = JsonConvert.SerializeObject(productCount, Formatting.Indented);



            return result;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(x => x.ProductsSold.Any(b => b.BuyerId != null))
                .Select(x => new
                {
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Where(a => a.BuyerId != null).Count(),
                        products = x.ProductsSold.Where(b => b.BuyerId != null).Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        })
                    }

                })
                .OrderByDescending(x => x.soldProducts.products.Count())
                .ToList();

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var resultObj = new
            {
                usersCount = users.Count(),
                users = users
            };


            var resultJson = JsonConvert.SerializeObject(resultObj, Formatting.Indented, jsonSerializerSettings);


            return resultJson;
        }

        private static IMapper InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}