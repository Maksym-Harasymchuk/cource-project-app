
using CourceProject.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourceProject.Models;

namespace CourceProject.Data
{
    public static class DBinitializer
    {
        public static async Task Initialize(CarsContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName ="bob",
                    Email="bob@test.com"
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");


                var admin = new User
                {
                    UserName ="admin",
                    Email="admin@test.com"
                };

                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, new[] { "Admin", "Member" });
            }

            if (context.Cars.Any()) return;

            var cars = new List<Car>
            {
                new Car()
                {
                    Manufacturer = "BMW",
                    Model = "i395",
                    Description = "The most beautiful car",
                    YearOfProduction = 1995,
                    AveragePrice = 45000,
                    Type = "Sedan",
                    QuantityInCountry = 999,
                    EngineDisplacement = "2",
                    EngineHorsepower = 250
                },
                new Car()
                {
                    Manufacturer = "AUDI",
                    Model = "A6",
                    Description = "The most beautiful car",
                    YearOfProduction = 1995,
                    AveragePrice = 45000,
                    Type = "Sedan",
                    QuantityInCountry = 999,
                    EngineDisplacement = "2",
                    EngineHorsepower = 250
                },
                new Car()
                {
                    Manufacturer = "MERCEDES",
                    Model = "i395",
                    Description = "The most beautiful car",
                    YearOfProduction = 1995,
                    AveragePrice = 45000,
                    Type = "Sedan",
                    QuantityInCountry = 999,
                    EngineDisplacement = "2",
                    EngineHorsepower = 250
                },
                new Car()
                {
                    Manufacturer = "FORD",
                    Model = "i395",
                    Description = "The most beautiful car",
                    YearOfProduction = 1995,
                    AveragePrice = 45000,
                    Type = "Sedan",
                    QuantityInCountry = 999,
                    EngineDisplacement = "2",
                    EngineHorsepower = 250
                },

            };

            foreach (var car in cars)
            {
                context.Cars.Add(car);
            }

            context.SaveChanges();
        }
    }
}
