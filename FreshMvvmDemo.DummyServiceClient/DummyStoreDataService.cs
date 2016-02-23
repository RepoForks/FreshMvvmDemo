using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvmDemo.Common;
using FreshMvvmDemo.Common.Models;

namespace FreshMvvmDemo.DummyServiceClient
{
    public class DummyStoreDataService : IStoreDataService
    {
        public async Task<Store[]> GetStores()
        {
            // Simulate server call
            await Task.Delay(1000);

            return new[]
            {
                new Store
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Store 1",
                    Location = "Chicago",
                    Employees = 422,
                },
                new Store
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Store 2",
                    Location = "Milwaukee",
                    Employees = 84,
                }
            };
        }

        public async Task<Product[]> GetProducts(Guid storeId)
        {
            // Simulate server call
            await Task.Delay(1000);

            return new[]
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Pizza",
                    Description = "Delicious. Loved by ninja turtles.",
                    Cost = 19.99m,
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Donuts",
                    Description = "Favorite confection of law enforcement.",
                    Cost = 4.50m,
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Ice Cream",
                    Description = "Comes in vanilla, chocolate, and red.",
                    Cost = 6.00m,
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Cake",
                    Description = "Not a lie.",
                    Cost = 12.00m,
                },
            };
        }
    }
}
