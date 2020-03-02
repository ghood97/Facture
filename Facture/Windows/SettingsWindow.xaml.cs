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
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();

            SetFields();

            areaCodeBox.TextChanged += AreaCodeBox_TextChanged;
            prefixBox.TextChanged += PrefixBox_TextChanged;
            saveSettingsButton.Click += SaveSettingsButton_Click;
        }

        private void SaveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.BusinessName = businessNameBox.Text;
            Properties.Settings.Default.Address = addressBox.Text;
            Properties.Settings.Default.City = cityBox.Text;
            Properties.Settings.Default.State = stateBox.Text;
            string phone = areaCodeBox.Text + prefixBox.Text + lineNumberBox.Text;
            Properties.Settings.Default.Phone = phone;
            Properties.Settings.Default.Save();
            Close();
        }

        private void PrefixBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(prefixBox.Text.Length == 3)
            {
                lineNumberBox.Focus();
            }
        }

        private void AreaCodeBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(areaCodeBox.Text.Length == 3)
            {
                prefixBox.Focus();
            }
        }

        private void SetFields()
        {
            businessNameBox.Text = Properties.Settings.Default.BusinessName;
            addressBox.Text = Properties.Settings.Default.Address;
            cityBox.Text = Properties.Settings.Default.City;
            stateBox.Text = Properties.Settings.Default.State;
            string phone = Properties.Settings.Default.Phone;
            areaCodeBox.Text = phone.Substring(0, 3);
            prefixBox.Text = phone.Substring(3, 3);
            lineNumberBox.Text = phone.Substring(6);
        }
    }
}
