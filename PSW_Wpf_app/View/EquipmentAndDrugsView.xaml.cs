using System;
using System.Windows;
using PSW_Wpf_app.ViewModel;

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for EquipmentAndDrugsView.xaml
    /// </summary>
    public partial class EquipmentAndDrugsView : Window
    {
        bool isDrug = false;
        public EquipmentAndDrugsView()
        {
            InitializeComponent();
        }

        private void OnEquipment(object sender, RoutedEventArgs e)
        {
            isDrug = false;
            this.userEqipmentAndDrugs.Content = new EquipmentView();
        }

        private void OnDrug(object sender, RoutedEventArgs e)
        {
            isDrug = true;
            this.userEqipmentAndDrugs.Content = new DrugsView();
        }

        private void OnSearch(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(searchText.Text))
            {
                EquipmentAndDrugsViewModel.SearchCommand.Execute($"{isDrug}_{searchText.Text}");
            }
            else
            {
                MessageBox.Show("You must enter equipment or drug for search.");
            }
        }
    }
}
