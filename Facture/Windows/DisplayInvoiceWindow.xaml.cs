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
    /// Interaction logic for DisplayInvoiceWindow.xaml
    /// </summary>
    public partial class DisplayInvoiceWindow : Window
    {
        private Invoice invoice;
        public DisplayInvoiceWindow(Invoice invoice)
        {
            InitializeComponent();
            this.invoice = invoice;
            GetInvoiceWithCildren();
            this.DataContext = this.invoice;
            SetPhoneBlocksAndDate();
            invoiceItemGridView.ItemsSource = this.invoice.InvoiceItems;
            editInvoiceButton.Click += EditInvoiceButton_Click;
        }

        private void EditInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            InvoiceWindow invoiceWindow = new InvoiceWindow(this.invoice);
            invoiceWindow.ShowDialog();
            GetInvoiceWithCildren();
        }

        private void GetInvoiceWithCildren()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                // get selected invoice with children
                this.invoice = connection.GetWithChildren<Invoice>(this.invoice.Id, recursive: true);

            }
            invoiceItemGridView.ItemsSource = this.invoice.InvoiceItems;
        }

        private void SetPhoneBlocksAndDate()
        {
            // set date TextBlock
            dateBlock.Text = this.invoice.Date.ToShortDateString();

            // set phone TextBlocks for BillTo and Business
            billToPhoneBlock.Text = processPhoneNumber(this.invoice.Phone);
            businessPhoneBlock.Text = processPhoneNumber(Properties.Settings.Default.Phone);
        }

        private string processPhoneNumber(string phone)
        {
            string areaCode, prefix, lineNumber;
            areaCode = phone.Substring(0, 3);
            prefix = phone.Substring(3, 3);
            lineNumber = phone.Substring(6);
            return "(" + areaCode + ")-" + prefix + "-" + lineNumber;
        }
    }
}
