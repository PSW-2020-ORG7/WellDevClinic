using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for EquipmentAndDrugsView.xaml
    /// </summary>
    public partial class EquipmentAndDrugsView : Window
    {
        public EquipmentAndDrugsView()
        {
            InitializeComponent();
        }

        private void OnEquipment(object sender, RoutedEventArgs e)
        {
            this.userEqipmentAndDrugs.Content = new EquipmentView();
        }

        private void OnDrug(object sender, RoutedEventArgs e)
        {
            this.userEqipmentAndDrugs.Content = new DrugsView();
        }
    }
}
