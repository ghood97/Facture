using Facture.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for NewInvoiceItemWindow.xaml
    /// </summary>
    public partial class NewInvoiceItemWindow : Window
    {
        Item item;
        InvoiceItem invoiceItem;
        public NewInvoiceItemWindow(Item item)
        {
            InitializeComponent();

            this.item = item;
            this.DataContext = this.item;

            quantityBox.KeyDown += QuantityBox_KeyDown;
            addToInvoiceButton.Click += AddToInvoiceButton_Click;

        }

        private void AddToInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(NewInvoiceWindow))
                {
                    this.item = (Item)(window as NewInvoiceWindow).itemGridView.SelectedItem;
                }
            }
            invoiceItem = new InvoiceItem()
            {
                ItemId = this.item.Id,
                Quantity = int.Parse(quantityBox.Text)
            };

            // Connects to database -- `using` statement closes connection after
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                // Creates the InvoiceItem table. Will be ignored if table already exists.
                connection.CreateTable<InvoiceItem>();
                connection.Insert(invoiceItem);
            }
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
