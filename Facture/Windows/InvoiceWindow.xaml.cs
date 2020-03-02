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
    /// Interaction logic for InvoiceWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        public Invoice invoice;
        List<Item> items;
        public List<InvoiceItem> invoiceItems;
        public InvoiceWindow(Invoice invoice)
        {
            InitializeComponent();
            invoiceItems = new List<InvoiceItem>();
            GetInvoiceWithChildren(invoice);
            this.DataContext = this.invoice;
            GetItems();

            deleteInvoiceButton.Click += DeleteInvoiceButton_Click;
            itemGridView.MouseDoubleClick += ItemGridView_MouseDoubleClick;
            invoiceItemGridView.MouseDoubleClick += InvoiceItemGridView_MouseDoubleClick;
            updateInvoiceButton.Click += UpdateInvoiceButton_Click;
        }

        private void UpdateInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                List<InvoiceItem> itemsToAdd = new List<InvoiceItem>();
                List<InvoiceItem> itemsNotChanged = new List<InvoiceItem>();
                foreach(InvoiceItem item in invoice.InvoiceItems)
                {
                    if(item.Id == 0)
                    {
                        itemsToAdd.Add(item);
                    }
                    else
                    {
                        itemsNotChanged.Add(item);
                    }
                }
                foreach(InvoiceItem invoiceItem in itemsToAdd)
                {
                    connection.Insert(invoiceItem);
                    invoiceItem.Item = connection.Get<Item>(invoiceItem.ItemId);
                    connection.UpdateWithChildren(invoiceItem);
                }
                invoice.InvoiceItems = itemsNotChanged.Concat(itemsToAdd).ToList();
                connection.UpdateWithChildren(invoice);
            }

            Close();
        }

        private void InvoiceItemGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            InvoiceItem selectedItem = (InvoiceItem)invoiceItemGridView.SelectedItem;
            if (selectedItem != null)
            {
                EDITEditInvoiceItemWindow editInvoiceItemWindow = new EDITEditInvoiceItemWindow(selectedItem, this);
                editInvoiceItemWindow.ShowDialog();
                invoiceItemGridView.Items.Refresh();
            }
        }

        private void ItemGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Item selectedItem = (Item)itemGridView.SelectedItem;
            if (selectedItem != null)
            {
                EDITNewInvoiceItemWindow invoiceItemWindow = new EDITNewInvoiceItemWindow(selectedItem);
                invoiceItemWindow.ShowDialog();
                invoiceItemGridView.Items.Refresh();
                // GetInvoiceItems();
            }
        }

        private void DeleteInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                // Creates the Invoice table. Will be ignored if table already exists.
                connection.CreateTable<Invoice>();
                // pass contact to Delete method
                connection.Delete(this.invoice);
            }

            Close();
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

        void GetInvoiceWithChildren(Invoice invoice)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                // gets all invoices
                this.invoice = connection.GetWithChildren<Invoice>(invoice.Id, recursive: true);

            }
        }
    }
}
