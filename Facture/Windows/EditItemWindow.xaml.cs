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
    /// Interaction logic for EditItemWindow.xaml
    /// </summary>
    public partial class EditItemWindow : Window
    {
        Item item;
        public EditItemWindow(Item item)
        {
            InitializeComponent();
            this.item = item;
            this.DataContext = this.item;

            updateItemButton.Click += UpdateItemButton_Click;
            deleteItemButton.Click += DeleteItemButton_Click;
        }

        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                // Creates the Item table. Will be ignored if table already exists.
                connection.CreateTable<Item>();
                // pass contact to Delete method
                connection.Delete(this.item);
            }

            Close();
        }

        private void UpdateItemButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                // Creates the Item table. Will be ignored if table already exists.
                connection.CreateTable<Item>();
                // pass item to Update method
                connection.Update(this.item);
            }

            Close();
        }
    }
}
