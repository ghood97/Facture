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
        public List<InvoiceItem> invoiceItems;
        public NewInvoiceWindow()
        {
            InitializeComponent();
            invoiceItems = new List<InvoiceItem>();

            GetItems();
            invoiceItemGridView.ItemsSource = invoiceItems;

            itemGridView.MouseDoubleClick += ItemGridView_MouseDoubleClick;
            invoiceItemGridView.MouseDoubleClick += InvoiceItemGridView_MouseDoubleClick;
            createInvoiceButton.Click += CreateInvoiceButton_Click;
        }

        // Creates a new Invoice object and persists it to the database
        private void CreateInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            string name = invoiceNameBox.Text;
            string address = invoiceAddressBox.Text;
            string city = invoiceCityBox.Text;
            string state = invoiceStateBox.Text;
            string phone = invoicePhoneBox.Text;
            // checks to make sure all textboxes are filled
            if(name != "" && address != "" && city != "" && state != "" && phone != "")
            {
                Invoice invoice = new Invoice()
                {
                    Date = DateTime.Now,
                    BillTo = name,
                    Address = address,
                    City = city,
                    State = state,
                    Phone = phone,
                };
                
                using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                {
                    // Creates table if it doesnt exist
                    connection.CreateTable<Invoice>();
                    connection.CreateTable<InvoiceItem>();
                    connection.Insert(invoice);
                    foreach (InvoiceItem i in this.invoiceItems)
                    {
                        connection.Insert(i);
                        i.Item = connection.Get<Item>(i.ItemId);
                        connection.UpdateWithChildren(i);
                    }
                    invoice.InvoiceItems = this.invoiceItems;
                    connection.UpdateWithChildren(invoice);
                }
                Close();
            }
            else
            {
                MessageBox.Show("You must enter a value for all fields.");
            }

        }

        private void InvoiceItemGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            InvoiceItem selectedItem = (InvoiceItem)invoiceItemGridView.SelectedItem;
            if (selectedItem != null)
            {
                EditInvoiceItemWindow editInvoiceItemWindow = new EditInvoiceItemWindow(selectedItem, this);
                editInvoiceItemWindow.ShowDialog();
                invoiceItemGridView.Items.Refresh();
            }
        }

        private void ItemGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Item selectedItem = (Item)itemGridView.SelectedItem;
            if (selectedItem != null)
            {
                NewInvoiceItemWindow invoiceItemWindow = new NewInvoiceItemWindow(selectedItem);
                invoiceItemWindow.ShowDialog();
                invoiceItemGridView.Items.Refresh();
                // GetInvoiceItems();
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
    }
}
