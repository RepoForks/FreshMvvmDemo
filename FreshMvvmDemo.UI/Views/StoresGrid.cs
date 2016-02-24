using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
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

        #region Stores Property

        public IEnumerable<Store> Stores
        {
            get { return (IEnumerable<Store>)GetValue(StoresProperty); }
            set { SetValue(StoresProperty, value); }
        }

        public static readonly BindableProperty StoresProperty =
            BindableProperty.Create<StoresGrid, IEnumerable<Store>>(
                x => x.Stores, null, BindingMode.OneWay, 
                propertyChanged: StoresPropertyChanged);

        private static void StoresPropertyChanged(BindableObject bindable, 
            IEnumerable<Store> oldvalue, IEnumerable<Store> newvalue)
        {
            ((StoresGrid)bindable).UpdateChildren();
        }

        #endregion Stores Property

        #region StoresSelectedCommand Property

        public ICommand StoreSelectedCommand
        {
            get { return (ICommand)GetValue(StoreSelectedCommandProperty); }
            set { SetValue(StoreSelectedCommandProperty, value); }
        }

        public static readonly BindableProperty StoreSelectedCommandProperty =
            BindableProperty.Create<StoresGrid, ICommand>(
                x => x.StoreSelectedCommand, null, BindingMode.OneWay,
                propertyChanged: StoreSelectedCommandPropertyChanged);

        private static void StoreSelectedCommandPropertyChanged(BindableObject bindable, 
            ICommand oldValue, ICommand newValue)
        {
            ((StoresGrid)bindable).UpdateChildren();
        }

        #endregion

        private readonly SemaphoreSlim _updateChildrenLock = new SemaphoreSlim(1);

        private async void UpdateChildren()
        {
            await _updateChildrenLock.WaitAsync();

            try
            {
                _grid.Children.Clear();

                _grid.RowDefinitions.Clear();
                _grid.RowDefinitions.Add(new RowDefinition {Height = GridLength.Auto});

                if (Stores == null) return;

                var column = 0;
                var row = 0;
                foreach (var store in Stores)
                {
                    if (column >= Columns)
                    {
                        _grid.RowDefinitions.Add(new RowDefinition {Height = GridLength.Auto});
                        column = 0;
                        row++;
                    }

                    var projectView = await Task.Run(() => new StoresGridTile(store, StoreSelectedCommand));
                    _grid.Children.Add(projectView, column, row);
                    column++;
                }
            }
            finally
            {
                _updateChildrenLock.Release();
            }
        }
    }
}
