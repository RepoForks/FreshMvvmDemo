using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvmDemo.Common.Models;
using Xamarin.Forms;

namespace FreshMvvmDemo.UI.Views
{
    public class ProductsList : ContentView
    {
        public ProductsList()
        {
            Content = _stackLayout;
        }

        private readonly StackLayout _stackLayout = new StackLayout {Orientation = StackOrientation.Vertical, Padding = 10};

        public IEnumerable<Product> Products
        {
            get { return (IEnumerable<Product>)GetValue(ProductsProperty); }
            set { SetValue(ProductsProperty, value); }
        }

        public static readonly BindableProperty ProductsProperty =
            BindableProperty.Create<ProductsList, IEnumerable<Product>>(
                x => x.Products, null, BindingMode.OneWay,
                propertyChanged: ProductsPropertyChanged);

        private static void ProductsPropertyChanged(BindableObject bindable, IEnumerable<Product> oldvalue, IEnumerable<Product> newvalue)
        {
            ((ProductsList)bindable).UpdateChildren();
        }

        private void UpdateChildren()
        {
            _stackLayout.Children.Clear();

            if (Products == null || !Products.Any())
                return;

            foreach (var product in Products)
            {
                _stackLayout.Children.Add(new ProductView(product));
            }
        }
    }
}
