using Facture.Windows;
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

            itemsButton.Click += ItemsButton_Click;
            newInvoiceButton.Click += NewInvoiceButton_Click;

            dateLabel.Text = DateTime.Now.ToString("dddd, MMM dd yyyy");
        }

        private void NewInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            NewInvoiceWindow invoiceWindow = new NewInvoiceWindow();
            invoiceWindow.Show();
        }

        private void ItemsButton_Click(object sender, RoutedEventArgs e)
        {
            ItemsWindow itemsWindow = new ItemsWindow() { Owner = this };
            itemsWindow.ShowDialog();
        }
    }
}
