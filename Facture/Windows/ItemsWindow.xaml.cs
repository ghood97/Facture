using Facture.Classes;
using SQLite;
using System;
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
        }

        private void SaveItemButton_Click(object sender, RoutedEventArgs e)
        {
            Item item = new Item()
            {
                Name = newItemNameBox.Text,
                Price = double.Parse(newItemPriceBox.Text),
                Unit = newItemUnitBox.Text
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
