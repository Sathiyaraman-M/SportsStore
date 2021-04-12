using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                        new Product
                        {
                            Name = "Kayak",
                            Description = "A boat for one person",
                            Category = "Watersports",
                            Price = 275,
                            StockQuantity = 24
                        },
                        new Product
                        {
                            Name = "Lifejacket",
                            Description = "Protective and fashionable",
                            Category = "Watersports",
                            Price = 48.95m,
                            StockQuantity = 75
                        },
                        new Product
                        {
                            Name = "Soccer Ball",
                            Description = "FIFA-approved size and weight",
                            Category = "Soccer",
                            Price = 19.50m,
                            StockQuantity = 278
                        },
                        new Product
                        {
                            Name = "Corner Flags",
                            Description = "Give your playing field a professional touch",
                            Category = "Soccer",
                            Price = 34.95m,
                            StockQuantity = 52
                        }, new Product
                        {
                            Name = "Stadium",
                            Description = "Flat-packed 35,000-seat stadium",
                            Category = "Soccer",
                            Price = 79500,
                            StockQuantity = 4
                        },
                        new Product
                        {
                            Name = "Thinking Cap",
                            Description = "Improve brain efficiency by 75%",
                            Category = "Chess",
                            Price = 16,
                            StockQuantity = 45
                        },
                        new Product
                        {
                            Name = "Unsteady Chair",
                            Description = "Secretly give your opponent a disadvantage",
                            Category = "Chess",
                            Price = 29.95m,
                            StockQuantity = 12
                        },
                        new Product
                        {
                            Name = "Human Chess Board",
                            Description = "A fun game for the family",
                            Category = "Chess",
                            Price = 75,
                            StockQuantity = 66
                        },
                        new Product
                        {
                            Name = "Bling-Bling King",
                            Description = "Gold-plated, diamond-studded King",
                            Category = "Chess",
                            Price = 1200,
                            StockQuantity = 2
                        });
                context.SaveChanges();
            }
        }
    }
}