using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvmDemo.Common.Models;
using Xamarin.Forms;

namespace FreshMvvmDemo.UI.Views
{
    public partial class StoresGridTile : ContentView
    {
        public StoresGridTile(Store store)
        {
            InitializeComponent();

            Store = store;
            BindingContext = store;
        }

        private Store Store { get; set; }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            // TODO: Send event back to page model
        }
    }
}
