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
    /// Interaction logic for ItemControl.xaml
    /// </summary>
    public partial class ItemControl : UserControl
    {


        public Item Item
        {
            get
            {
                return (Item)GetValue(ItemProperty);
            }
            set
            {
                SetValue(ItemProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for Item.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemProperty =
            DependencyProperty.Register("Item", typeof(Item), typeof(ItemControl), new PropertyMetadata(new Item()  { Name="Floodlight", Price=7.99, Unit="bulb"}, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ItemControl control = d as ItemControl;
            if(control != null)
            {
                control.nameTextBlock.Text = (e.NewValue as Item).Name;
                control.priceTextBlock.Text = (e.NewValue as Item).Price.ToString();
                control.unitTextBlock.Text = (e.NewValue as Item).Unit;
            }
        }

        public ItemControl()
        {
            InitializeComponent();
        }
    }
}
