using Facture.Classes;
using SQLite;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Facture.Windows
{
    /// <summary>
    /// Interaction logic for ItemsWindow.xaml
    /// </summary>
    public partial class ItemsWindow : Window
    {
        List<Item> items;
        public ItemsWindow()
        {
            InitializeComponent();
            GetItems();

            items = new List<Item>();

            saveItemButton.Click += SaveItemButton_Click;
            itemGridView.MouseDoubleClick += ItemGridView_MouseDoubleClick;
        }

        private void ItemGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Item selectedItem = (Item)itemGridView.SelectedItem;
            if (selectedItem != null)
            {
                EditItemWindow editItemWindow = new EditItemWindow(selectedItem);
                editItemWindow.ShowDialog();
            }
            GetItems();
            
        }

        private void SaveItemButton_Click(object sender, RoutedEventArgs e)
        {
            string name;
            decimal price;
            string unit;

            // check to make sure string fields arent empty
            if(newItemNameBox.Text != "" && newItemUnitBox.Text != "")
            {
                name = newItemNameBox.Text;
                unit = newItemUnitBox.Text;
                if (Decimal.TryParse(newItemPriceBox.Text, out price))
                {
                    Item item = new Item()
                    {
                        Name = name,
                        Price = price,
                        Unit = unit
                    };
                    // Connects to database -- `using` statement closes connection after
                    using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                    {
                        // Creates the Contact table. Will be ignored if table already exists.
                        connection.CreateTable<Item>();
                        connection.Insert(item);
                    }

                    ResetTextBox();
                    GetItems();

                }
                else
                {
                    MessageBox.Show("Please Enter a real dollar amount in the 'Price' field.");
                }
            }
            else
            {
                MessageBox.Show("You must enter a value for all fields.");
            }
        }

        void GetItems()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                // Creates table if it doesnt exist
                connection.CreateTable<Item>();
                // Get contacts as a list, order them by name, then conver to list again
                // (because OrderBy returns an IOrderedEnumerable)
                items = connection.Table<Item>().ToList().OrderBy(c => c.Name).ToList();
            }
            if (items != null)
            {
                items.Sort((x, y) => x.Name.CompareTo(y.Name));
                itemGridView.ItemsSource = items;
            }
        }

        private void ResetTextBox()
        {
            newItemNameBox.Text = "";
            newItemPriceBox.Text = "";
            newItemUnitBox.Text = "";
        }
    }
}
