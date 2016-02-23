using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvmDemo.Common.Models;

namespace FreshMvvmDemo.Common
{
    public interface IStoreDataService
    {
        Task<Store[]> GetStores();
        Task<Product[]> GetProducts(Guid storeId);
    }
}
