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
            _storeDataService = FreshIOC.Container.Resolve<IStoreDataService>();
            RefreshCommand = new Command(LoadStores);
        }

        private readonly IStoreDataService _storeDataService;

        public override void Init(object initData)
        {
            LoadStores();

            base.Init(initData);
        }

        public bool Loading { get; private set; }
        public bool NotLoading { get { return !Loading; } }

        public Store[] Stores { get; private set; }

        public readonly ICommand RefreshCommand;

        private async void LoadStores()
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
