using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvmDemo.Common.Models;
using Xamarin.Forms;

namespace FreshMvvmDemo.UI.Views
{
    public partial class StoresGridTile : ContentView
    {
        public StoresGridTile(Store store, ICommand storeSelectedCommand)
        {
            InitializeComponent();

            Store = store;
            StoreSelectedCommand = storeSelectedCommand;

            BindingContext = Store;
        }

        private Store Store { get; set; }

        private ICommand StoreSelectedCommand { get; set; }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            StoreSelectedCommand.Execute(Store);
        }
    }
}
