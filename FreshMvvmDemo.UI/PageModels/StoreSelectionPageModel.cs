using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using FreshMvvmDemo.Common;
using FreshMvvmDemo.Common.Models;
using PropertyChanged;
using Xamarin.Forms;

namespace FreshMvvmDemo.UI.PageModels
{
    [ImplementPropertyChanged]
    public class StoreSelectionPageModel : FreshBasePageModel
    {
        public StoreSelectionPageModel()
        {
            Stores = new Store[0];

            _storeDataService = FreshIOC.Container.Resolve<IStoreDataService>();

            RefreshCommand = new Command(Refresh);
            StoreSelectedCommand = new Command<Store>(StoreSelected);
        }

        private readonly IStoreDataService _storeDataService;

        public override async void Init(object initData)
        {
            await LoadStores();

            base.Init(initData);
        }

        public bool Loading { get; private set; }
        public bool NotLoading { get { return !Loading; } }

        public Store[] Stores { get; private set; }

        public ICommand RefreshCommand { get; private set; }
        private async void Refresh()
        {
            await LoadStores();
        }

        public ICommand StoreSelectedCommand { get; private set; }
        private async void StoreSelected(Store store)
        {
            await CoreMethods.PushPageModel<StoreDetailsPageModel>(store);
        }

        private async Task LoadStores()
        {
            try
            {
                Loading = true;

                var stores = await _storeDataService.GetStores();
                Stores = stores;
            }
            finally
            {
                Loading = false;
            }
        }

    }
}
