using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using FreshMvvmDemo.Common;
using FreshMvvmDemo.DummyServiceClient;
using FreshMvvmDemo.UI.PageModels;
using Xamarin.Forms;

namespace FreshMvvmDemo.UI
{
    public class App : Application
    {
        public App()
        {
            Bootstrap();

            var page = FreshPageModelResolver.ResolvePageModel<StoreSelectionPageModel>();
            var navigation = new FreshNavigationContainer(page);
            MainPage = navigation;
        }

        private static void Bootstrap()
        {
            FreshIOC.Container.Register<IStoreDataService, DummyStoreDataService>().AsSingleton();
        }
    }
}
