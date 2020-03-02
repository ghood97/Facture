using Facture.Classes;
using Facture.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Facture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // DeleteInvoiceAndInvoiceItems();

            // Test();

            itemsButton.Click += ItemsButton_Click;
            newInvoiceButton.Click += NewInvoiceButton_Click;
            viewInvoicesButton.Click += ViewInvoicesButton_Click;
            settingsButton.Click += SettingsButton_Click;

            dateLabel.Text = DateTime.Now.ToString("dddd, MMM dd yyyy");
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
        }

        private void ViewInvoicesButton_Click(object sender, RoutedEventArgs e)
        {
            InvoicesWindow invoicesWindow = new InvoicesWindow();
            invoicesWindow.ShowDialog();
        }

        private void NewInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            NewInvoiceWindow invoiceWindow = new NewInvoiceWindow();
            invoiceWindow.ShowDialog();
        }

        private void ItemsButton_Click(object sender, RoutedEventArgs e)
        {
            ItemsWindow itemsWindow = new ItemsWindow() { Owner = this };
            itemsWindow.ShowDialog();
        }

        private void Test()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                // gets all invoices
                List<Invoice> invoices = connection.GetAllWithChildren<Invoice>(recursive: true).ToList();

            }
        }

        private void DeleteInvoiceAndInvoiceItems()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.DeleteAll<InvoiceItem>();
                connection.DeleteAll<Invoice>();
            }
        }
    }
}
