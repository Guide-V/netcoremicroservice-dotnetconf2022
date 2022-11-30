using FleetsApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FleetsApi.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FleetsApiContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<FleetsApiContext>>()))
            {
                // Look for any movies.
                if (context.Fleet.Any())
                {
                    return;   // DB has been seeded
                }

                context.Fleet.AddRange(
                    new Fleet
                    {
                        Brand = "Toyota Supra",
                        Color = "red",
                        Status = "Stop"
                    },
                    new Fleet
                    {
                        Brand = "Izuzu All-New DMAX",
                        Color = "blue",
                        Status = "Running"
                    },
                    new Fleet
                    {
                        Brand = "Honda Type-R",
                        Color = "White",
                        Status = "Idle"
                    }
                );

                if (context.Driver.Any())
                {
                    return;   // DB has been seeded
                }

                context.Driver.AddRange(
                    new Driver
                    {
                        FirstName = "Bunta",
                        LastName= "Fujiwara",
                        Employed = true,
                    },
                    new Driver
                    {
                        FirstName = "Takumi",
                        LastName = "Fujiwara",
                        Employed = true,
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
