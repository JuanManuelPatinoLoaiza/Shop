﻿
namespace Shop.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Products.Any())
            {
                this.AddProduct("iPhone Plus");
                this.AddProduct("Tablet X200");
                this.AddProduct("Laptop XR80");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailabe = true,
                Stock = this.random.Next(100)
            });
        }
    }

}
