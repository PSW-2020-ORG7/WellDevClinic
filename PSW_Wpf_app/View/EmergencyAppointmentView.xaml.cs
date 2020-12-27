using PSW_Wpf_app.Client;
using PSW_Wpf_app.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for EmergencyAppointmentView.xaml
    /// </summary>
    public partial class EmergencyAppointmentView : Window
    {
        EmergencyAppointmentViewModel context;
        public EmergencyAppointmentView()
        {
            InitializeComponent();
            

        }
        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = await WpfClient.GetPatientByJmbg(jmbg.Text);
            if(patient == null)
            {
                MessageBox.Show("Searched patient does not exist.Please register patient!");
                
            }
            else
            {
                name.Text = patient.FirstName;
                surname.Text = patient.LastName;
                phone.Text = patient.Phone;
                jmbgpatient.Text = patient.Jmbg;
            }
            
        }
        
        private void Search_Term_Click(object sender, RoutedEventArgs e)
        {
            int selected = apptype.SelectedIndex;
            context = new EmergencyAppointmentViewModel(apptype.SelectedIndex);
            emergencyData.ItemsSource = context.Examinations;

        }

        private void Schedule_Term_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
