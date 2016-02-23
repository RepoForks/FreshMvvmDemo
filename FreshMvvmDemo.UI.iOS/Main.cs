using FreshMvvm;
using FreshMvvmDemo.Common;
using FreshMvvmDemo.DummyServiceClient;
using UIKit;

namespace FreshMvvmDemo.UI.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            FreshIOC.Container.Register<IStoreDataService, DummyStoreDataService>().AsSingleton();

            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}