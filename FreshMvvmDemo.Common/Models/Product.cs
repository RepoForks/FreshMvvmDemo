using System;

namespace FreshMvvmDemo.Common.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
    }
}
