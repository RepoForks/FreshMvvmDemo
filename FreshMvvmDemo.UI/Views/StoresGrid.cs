using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvmDemo.Common.Models;
using Xamarin.Forms;

namespace FreshMvvmDemo.UI.Views
{
    public class StoresGrid : ScrollView
    {
        public StoresGrid()
        {
            this.Content = _grid;
            Columns = 2;
        }

        private readonly Grid _grid = new Grid();

        public int Columns { get; private set; }

        public IEnumerable<Store> Stores
        {
            get { return (IEnumerable<Store>)GetValue(StoresProperty); }
            set { SetValue(StoresProperty, value); }
        }

        public static readonly BindableProperty StoresProperty =
            BindableProperty.Create<StoresGrid, IEnumerable<Store>>(
                x => x.Stores, null, BindingMode.OneWay, propertyChanging: StoresPropertyChanging);

        private static void StoresPropertyChanging(BindableObject bindable, IEnumerable<Store> oldvalue, IEnumerable<Store> newvalue)
        {
            ((StoresGrid)bindable).UpdateChildren(newvalue);
        }

        private async void UpdateChildren(IEnumerable<Store> stores)
        {
            _grid.Children.Clear();

            _grid.RowDefinitions.Clear();
            _grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            if (Stores == null) return;

            var column = 0;
            var row = 0;
            foreach (var store in stores)
            {
                if (column >= Columns)
                {
                    _grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    column = 0;
                    row++;
                }

                var projectView = await Task.Run(() => new StoresGridTile(store));
                _grid.Children.Add(projectView, column, row);
                column++;
            }
        }
    }
}
