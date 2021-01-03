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
        Patient patient = new Patient();
        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            patient = await WpfClient.GetPatientByJmbg(jmbg.Text);
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
            Equipment equipment = (Equipment)equip.SelectedItem;
            context = new EmergencyAppointmentViewModel(apptype.SelectedIndex, equipment);
            emergencyData.ItemsSource = context.Examinations;

        }

        private async void Schedule_Term_Click(object sender, RoutedEventArgs e)
        {
            ExaminationDTO examinationDTO = (ExaminationDTO)emergencyData.SelectedItem;
            examinationDTO.Patient = patient;
            Examination examination = (Examination)await WpfClient.NewExamination(examinationDTO);


            if (examination != null)
            {
                MessageBox.Show("Appointment is scheduled!");
            }
        }

        private void Analysis_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" Appointment Analysis\n\n" +

                "If there are no free terms software will automatically call appointment analysis.\n" +
                "It's implemented to set emergency appointment as priority.\n" +
                "It will return 3 best options. You can choose one of them and delay \n" +
                "scheduled appointment for later and instead of it we will set emergency appointment.\n" +
                "Given options are sorted from good to less good,\n" +
                "based on rescheduling delayed appointment.\n" +
                "");
        }

        private void Solution_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private async void Schedule_And_Dilay_Term_Click(object sender, RoutedEventArgs e)
        {
           
        }

    }
}
