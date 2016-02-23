using System;
using System.Threading;
using System.Threading.Tasks;
using FreshMvvm;
using FreshMvvmDemo.Common;
using FreshMvvmDemo.Common.Models;

namespace FreshMvvmDemo.UI.PageModels
{
    public class StoreSelectionPageModel : FreshBasePageModel
    {
        public StoreSelectionPageModel()
        {
            _storeDataService = FreshIOC.Container.Resolve<IStoreDataService>();
        }

        private readonly IStoreDataService _storeDataService;

        public override void Init(object initData)
        {
            LoadStores();

            base.Init(initData);
        }

        private readonly SemaphoreSlim _storesLoadingLock = new SemaphoreSlim(1);
        public bool StoresLoading { get; private set; }
        public Store[] Stores { get; private set; }

        private async void LoadStores()
        {
            if (!_storesLoadingLock.Wait(0))
                return;

            try
            {
                StoresLoading = true;

                var stores = await _storeDataService.GetStores();
                Stores = stores;
            }
            finally
            {
                StoresLoading = false;
                _storesLoadingLock.Release();
            }
        }
    }
}
