using Facture.Classes;
using SQLite;
using SQLiteNetExtensions.Extensions;
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
    /// Interaction logic for EDITEditInvoiceItemWindow.xaml
    /// </summary>
    public partial class EDITEditInvoiceItemWindow : Window
    {
        InvoiceItem invoiceItem;
        InvoiceWindow invoiceWindow;
        public EDITEditInvoiceItemWindow(InvoiceItem invoiceItem, InvoiceWindow invoiceWindow)
        {
            InitializeComponent();

            this.invoiceItem = invoiceItem;
            this.invoiceWindow = invoiceWindow;
            this.DataContext = this.invoiceItem;

            quantityBox.KeyDown += QuantityBox_KeyDown;
            deleteInvoiceItemButton.Click += DeleteInvoiceItemButton_Click;
            updateQuantityButton.Click += UpdateQuantityButton_Click;
        }

        private void UpdateQuantityButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (InvoiceItem itemToUpdate in invoiceWindow.invoice.InvoiceItems)
            {
                if (itemToUpdate.ItemId == this.invoiceItem.ItemId)
                {
                    itemToUpdate.Quantity = int.Parse(quantityBox.Text);
                    using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                    {
                        connection.UpdateWithChildren(itemToUpdate);
                    }
                    break;
                }
            }

            Close();
        }

        private void DeleteInvoiceItemButton_Click(object sender, RoutedEventArgs e)
        {
            this.invoiceWindow.invoice.InvoiceItems.Remove(this.invoiceItem);

            Close();
        }

        private void QuantityBox_KeyDown(object sender, KeyEventArgs e)
        {
            // can't find solution to convert the KeyPressed into a char representation
            // e.Key.ToString() evaluates to `Dx` for numbers and `NumPadx` for numpad numbers
            // e.Key.ToString() is checked for in the systemKeys array and if it is there,
            // you can type it into the text box
            string key = e.Key.ToString();
            string[] systemKeys = new string[] { "D1", "D2", "D3", "D4",
                                                 "D5", "D6", "D7", "D8",
                                                 "D9", "D0", "NumPad0", "NumPad1",
                                                 "NumPad2", "NumPad3", "NumPad4",
                                                 "NumPad5", "NumPad6", "NumPad7",
                                                 "NumPad8", "NumPad9"};
            e.Handled = !systemKeys.Contains(e.Key.ToString());
        }
    }
}
