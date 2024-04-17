using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.Extensions.Logging;

namespace Infrastructure.DataContext
{
    public class ApplicationDbContextSeeding
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext,ILoggerFactory loggerFactory)
        {
            try
            {
                if(!dbContext.ProductBrands.Any())
                {
                    var brandData=File.ReadAllText("../Infrastructure/DataSeeding/productBrands.json");

                    var brands=JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

                    foreach(var item in brands)
                    {
                        dbContext.ProductBrands.Add(item);
                    }
                    await dbContext.SaveChangesAsync();
                }

                if(!dbContext.ProductTypes.Any())
                {
                    var TypeData=File.ReadAllText("../Infrastructure/DataSeeding/productTypes.json");

                    var Types=JsonSerializer.Deserialize<List<ProductType>>(TypeData);

                    foreach(var item in Types)
                    {
                        dbContext.ProductTypes.Add(item);
                    }
                    await dbContext.SaveChangesAsync();
                }

                if(!dbContext.Products.Any())
                {
                    var Productslist=File.ReadAllText("../Infrastructure/DataSeeding/products.json");

                    var Productsls=JsonSerializer.Deserialize<List<Product>>(Productslist);

                    foreach(var item in Productsls)
                    {
                        dbContext.Products.Add(item);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger=loggerFactory.CreateLogger<ApplicationDbContextSeeding>();
                logger.LogError(ex.Message);
            }
        }
    }
}