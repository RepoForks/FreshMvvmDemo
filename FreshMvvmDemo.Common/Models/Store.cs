using System;

namespace FreshMvvmDemo.Common.Models
{
    public class Store
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public int Employees { get; set; }
    }
}
