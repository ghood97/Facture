using Facture.Classes;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for NewInvoiceWindow.xaml
    /// </summary>
    public partial class NewInvoiceWindow : Window
    {
        List<Item> items;
        List<InvoiceItem> invoiceItems;
        public NewInvoiceWindow()
        {
            InitializeComponent();

            GetItems();
            GetInvoiceItems();

            itemGridView.MouseDoubleClick += ItemGridView_MouseDoubleClick;
            invoiceItemGridView.MouseDoubleClick += InvoiceItemGridView_MouseDoubleClick;
        }

        private void InvoiceItemGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            InvoiceItem selectedItem = (InvoiceItem)invoiceItemGridView.SelectedItem;
            if (selectedItem != null)
            {
                EditInvoiceItemWindow editInvoiceItemWindow = new EditInvoiceItemWindow(selectedItem);
                editInvoiceItemWindow.ShowDialog();
            }
            GetInvoiceItems();
        }

        private void ItemGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Item selectedItem = (Item)itemGridView.SelectedItem;
            if (selectedItem != null)
            {
                NewInvoiceItemWindow invoiceItemWindow = new NewInvoiceItemWindow(selectedItem);
                invoiceItemWindow.ShowDialog();
                GetInvoiceItems();
            }
        }

        void GetItems()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                // Creates table if it doesnt exist
                connection.CreateTable<Item>();
                // Get items as a list, order them by name, then conver to list again
                // (because OrderBy returns an IOrderedEnumerable)
                items = connection.Table<Item>().ToList().OrderBy(c => c.Name).ToList();
            }
            if (items != null)
            {
                itemGridView.ItemsSource = items;
            }
        }

        void GetInvoiceItems()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                // Creates table if it doesnt exist
                connection.CreateTable<InvoiceItem>();
                // Get invoiceItems as a list, order them by name, then convert to list again
                // (because OrderBy returns an IOrderedEnumerable)
                invoiceItems = connection.GetAllWithChildren<InvoiceItem>().ToList();
            }
            if (invoiceItems != null)
            {
                invoiceItemGridView.ItemsSource = invoiceItems;
            }
        }
    }
}
