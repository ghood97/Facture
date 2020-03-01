using Facture.Classes;
using System;
using SQLite;
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
    /// Interaction logic for InvoicesWindow.xaml
    /// </summary>
    public partial class InvoicesWindow : Window
    {
        List<Invoice> invoices;

        public InvoicesWindow()
        {
            InitializeComponent();

            GetInvoices();

            invoiceListView.SelectionChanged += InvoiceListView_SelectionChanged;

        }

        private void InvoiceListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Invoice selectedInvoice = (Invoice)invoiceListView.SelectedItem;
            if (selectedInvoice != null)
            {
                // create edit invoice window
            }
            GetInvoices();
        }

        void GetInvoices()
        {
            using (SQLite.SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Invoice>();
                this.invoices = connection.Table<Invoice>().ToList().OrderBy(x => x.Date).ToList();
            }

            if(this.invoices != null)
            {
                invoiceListView.ItemsSource = this.invoices;
            }
        }
    }
}
