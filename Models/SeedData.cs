using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Tuskla.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            {
                using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
                {
                    if (!context.Products.Any())
                    {
                        context.Products.AddRange(
                        new ProductModelView
                        {
                            ProductID = 1,
                            Name = "Model 3 Standard",
                            Description = "Model 3 Base $46,000.00",
                            Price = 46000.00M,
                            Category = "Car",
                            isActive = true
                            
                        },
                        new ProductModelView
                        {
                            ProductID = 2,
                            Name = "Model 3 Plaid",
                            Description = "Model 3 Dual Motor $61,000.00",
                            Price = 61000.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 3,
                            Name = "Model Y Standard",
                            Description = "Model Y Long Range $67,900.00",
                            Price = 67900.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 4,
                            Name = "Model Y Plaid",
                            Description = "Model Y Performance $69,990.00",
                            Price = 69900.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 5,
                            Name = "Model X Standard",
                            Description = "Model X Dual Motor $126490.00",
                            Price = 126490.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 6,
                            Name = "Model X Plaid",
                            Description = "Model X Plaid Tri Motor $144,490.00",
                            Price = 144490.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 7,
                            Name = "Model S Standard",
                            Description = "Model S Dual Motor $109,490.00",
                            Price = 109490.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 8,
                            Name = "Model S Plaid",
                            Description = "Model S Plaid Tri Motor $140,490.00",
                            Price = 140490.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 9,
                            Name = "Paint",
                            Description = "Pearl White +$0.00",
                            Price = 0.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 10,
                            Name = "Paint",
                            Description = "Midnight Silver Metallic +$0.00",
                            Price = 0.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 11,
                            Name = "Paint",
                            Description = "Deep Blue Metallic +$1,000.00",
                            Price = 1000.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 12,
                            Name = "Paint",
                            Description = "Solid Black +$1,500.00",
                            Price = 1500.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 13,
                            Name = "Paint",
                            Description = "Red Multi-Coat +2,000.00",
                            Price = 2000.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 14,
                            Name = "Interior",
                            Description = "Black +$0.00",
                            Price = 0.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 15,
                            Name = "Interior",
                            Description = "Black & White +$1500.00",
                            Price = 1500.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 16,
                            Name = "Rims",
                            Description = "18 Inch + $0.00",
                            Price = 0.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 17,
                            Name = "Rims",
                            Description = "19 Inch + $2,000.00",
                            Price = 2000.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 18,
                            Name = "AutoPilot",
                            Description = "Standard AutoPilot +$0.00",
                            Price = 0.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 19,
                            Name = "AutoPilot",
                            Description = "Enhanced AutoPilot + $6,000",
                            Price = 6000.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 20,
                            Name = "FullSelfDriving",
                            Description = "Full Self Driving - None +$0.00",
                            Price = 0.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 21,
                            Name = "FullSelfDriving",
                            Description = "Full Self Driving - Included +$15000.00",
                            Price = 15000.00M,
                            Category = "Car",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 22,
                            Name = "FloorMats",
                            Description = "Luxury Floor Mats $95.00",
                            Price = 95.00M,
                            Category = "Interior",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 23,
                            Name = "DashCover",
                            Description = "Luxury Dash Cover $65.00",
                            Price = 65.00M,
                            Category = "Interior",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 24,
                            Name = "BabySeat",
                            Description = "Baby Seat $100.00",
                            Price = 100.00M,
                            Category = "Interior",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 25,
                            Name = "RoofRack",
                            Description = "Roof Rack $750.00",
                            Price = 750.00M,
                            Category = "Exterior",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 26,
                            Name = "FrontLicensePlate",
                            Description = "Front License Plate $85.00",
                            Price = 85.00M,
                            Category = "Exterior",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 27,
                            Name = "CarSoap",
                            Description = "Premium Car Soap $22.00",
                            Price = 22.00M,
                            Category = "Maintenance",
                            isActive = true

                        },
                        new ProductModelView
                        {
                            ProductID = 28,
                            Name = "CarWax",
                            Description = "Premium Car Wax $35.00",
                            Price = 35.00M,
                            Category = "Maintenance",
                            isActive = true

                        });
                    }

                    if (!context.Users.Any())
                    {
                        context.Users.Add(new AppUser
                        {
                            Id = new Guid("f70230f5-aae7-4357-96b3-08dac66fa512"),
                            UserName = "admin",
                            NormalizedUserName = "ADMIN",
                            Email = "admin@evehicles.com",
                            NormalizedEmail = "ADMIN@EVEHICLES.COM",
                            EmailConfirmed = false,
                            // Temp01#
                            PasswordHash = "AQAAAAEAACcQAAAAELmEcW2NLu61UhgG/X6uZQcThxGmkN0ySoVt3+O/rkizpw6UGJrknH6/UeOrcxpyKw==",
                            SecurityStamp = "JP7FUQ5ZKICTBGHF5GHZW5TGXO2GY7AO",
                            ConcurrencyStamp = "f6d3c77a-cbda-4518-b64c-22e30b62a428",
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0
                        });
                    }
                    context.SaveChanges();
                }
            }   
        }
    }
}
