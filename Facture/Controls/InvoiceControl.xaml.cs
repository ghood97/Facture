using Facture.Classes;
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

namespace Facture.Controls
{
    /// <summary>
    /// Interaction logic for InvoiceControl.xaml
    /// </summary>
    public partial class InvoiceControl : UserControl
    {


        public Invoice Invoice
        {
            get { return (Invoice)GetValue(InvoiceProperty); }
            set { SetValue(InvoiceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Invoice.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InvoiceProperty =
            DependencyProperty.Register("Invoice", typeof(Invoice), typeof(InvoiceControl), new PropertyMetadata(new Invoice() { BillTo = "Error" }, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            InvoiceControl control = d as InvoiceControl;
            if(control != null)
            {
                control.dateBlock.Text = (e.NewValue as Invoice).Date.ToShortDateString();
                control.nameBlock.Text = (e.NewValue as Invoice).BillTo;
                control.addressBlock.Text = (e.NewValue as Invoice).Address;
                control.cityBlock.Text = (e.NewValue as Invoice).City;
                control.stateBlock.Text = (e.NewValue as Invoice).State;
                control.phoneBlock.Text = (e.NewValue as Invoice).Phone;
            }
        }

        public InvoiceControl()
        {
            InitializeComponent();
        }
    }
}
