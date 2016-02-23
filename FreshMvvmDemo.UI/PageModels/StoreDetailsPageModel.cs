using System;
using System.Threading;
using System.Threading.Tasks;
using FreshMvvm;
using FreshMvvmDemo.Common;
using FreshMvvmDemo.Common.Models;

namespace FreshMvvmDemo.UI.PageModels
{
    public class StoreDetailsPageModel : FreshBasePageModel
    {
        public StoreDetailsPageModel()
        {
            _storeDataService = FreshIOC.Container.Resolve<IStoreDataService>();
        }

        private readonly IStoreDataService _storeDataService;

        public override void Init(object initData)
        {
            var store = initData as Store;
            if (store == null)
                throw new ArgumentException("Could not load store details page with null init data.");

            Store = store;

            LoadProducts();

            base.Init(initData);
        }

        public Store Store { get; private set; }

        private readonly SemaphoreSlim _productsLoadingLock = new SemaphoreSlim(1);
        public bool ProductsLoading { get; private set; }
        public Product[] Products { get; private set; }

        private async void LoadProducts()
        {
            if (!_productsLoadingLock.Wait(0))
                return;

            try
            {
                ProductsLoading = true;
                
                var storeProducts = await _storeDataService.GetProducts(Store.Id);
                Products = storeProducts;
            }
            finally
            {
                ProductsLoading = false;
                _productsLoadingLock.Release();
            }
        }
    }
}
