using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvmDemo.Common.Models;
using PropertyChanged;
using Xamarin.Forms;

namespace FreshMvvmDemo.UI.Views
{
    [ImplementPropertyChanged]
    public partial class ProductView : ContentView
    {
        public ProductView(Product product)
        {
            InitializeComponent();

            Product = product;
            BindingContext = Product;
        }

        public readonly Product Product;
    }
}
