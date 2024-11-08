using ecommerce.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Data
{
    public class ContextSeed
    {
        public static async Task SeedAsync(Context Context, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                if (!Context.Categories.Any())
                {
                    Context.Categories.AddRange(GetPreconfiguredCategories());
                    await Context.SaveChangesAsync();
                }

                if (!Context.Products.Any())
                {
                    Context.Products.AddRange(GetPreconfiguredProducts());
                    await Context.SaveChangesAsync();
                }
            }
            
        }
    }
}