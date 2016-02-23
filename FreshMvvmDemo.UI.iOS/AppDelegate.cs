using Foundation;
using UIKit;
using Xamarin.Forms;

namespace FreshMvvmDemo.UI.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(application, launchOptions);
        }
    }
}
