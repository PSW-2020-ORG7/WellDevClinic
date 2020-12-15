
using System.Windows;

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for BuildingsInformationView.xaml
    /// </summary>
    public partial class BuildingsInformationView : Window
    {
        public BuildingsInformationView()
        {
            InitializeComponent();

        }

        private void OnSurgical(object sender, RoutedEventArgs e)
        {
            this.user2.Content = new Surgical();
        }

        private void OnMedicalCenter(object sender, RoutedEventArgs e)
        {
            this.user2.Content = new MedicalCenter();
        }

        private void OnPediatrics(object sender, RoutedEventArgs e)
        {
            this.user2.Content = new Pediatrics();
            
        }
    }
}
