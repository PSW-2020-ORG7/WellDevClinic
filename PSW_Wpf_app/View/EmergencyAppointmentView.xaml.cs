using PSW_Wpf_app.Client;
using PSW_Wpf_app.Model;
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
                name.Text = patient.Person.FirstName;
                surname.Text = patient.Person.LastName;
                phone.Text = patient.UserDetails.Phone;
                jmbgpatient.Text = patient.Person.Jmbg;
            }
            
        }
        
        private void Search_Term_Click(object sender, RoutedEventArgs e)
        {
            int selected = apptype.SelectedIndex;
            Equipment equipment = (Equipment)equip.SelectedItem;
            context = new EmergencyAppointmentViewModel(apptype.SelectedIndex, equipment);
            emergencyData.ItemsSource = context.Examinations;
            analysisData.ItemsSource = context.ExaminationForDilay;

        }

        private async void Schedule_Term_Click(object sender, RoutedEventArgs e)
        {
            ExaminationDTO ex = (ExaminationDTO)emergencyData.SelectedItem;
            UpcomingExamination upcoming = new UpcomingExamination(ex.Doctor, ex.Period, patient);

            UpcomingExamination examination = (UpcomingExamination)await WpfClient.NewExamination(upcoming);


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
            int izbor = analysisData.SelectedIndex;
            List<double> minutes = context.DileyTime;
            List<ExaminationDTO> proba = context.DelayedTermExamination;

            AppointmentAnalysisView appointmentAnalisys = new AppointmentAnalysisView(minutes[analysisData.SelectedIndex], proba[analysisData.SelectedIndex]);

            appointmentAnalisys.Show();
        }

        private async void Schedule_And_Dilay_Term_Click(object sender, RoutedEventArgs e)
        {
            int selected = analysisData.SelectedIndex;
            Examination examination = (Examination)analysisData.SelectedItem;
            List<ExaminationDTO> examinationDTO = context.DelayedTermExamination;
            ExaminationDTO ex = examinationDTO[selected];
            ex.Patient = examination.Patient;
            UpcomingExamination upcoming = new UpcomingExamination(ex.Doctor, ex.Period, ex.Patient);
            UpcomingExamination examinationNew = (UpcomingExamination)await WpfClient.NewExamination(upcoming);


            examination.Patient = patient;
            WpfClient.EditExamination(examination);
            MessageBox.Show("Term is dilayed!");
        }

        private async void NewPatientClick(object sender, RoutedEventArgs e)
        {
            Patient patient = new Patient();

            patient.Person.FirstName = name.Text;
            patient.Person.LastName = surname.Text;
            patient.UserDetails.Phone = phone.Text;
            patient.Person.Jmbg = jmbgpatient.Text;
            patient.UserLogIn.Username = name.Text;
            patient.UserDetails.Image = ";" + name.Text + ".jpg" + ",";
            patient.Guest = true;
            

            Patient p = await WpfClient.SavePatient(patient);
            if (p != null)
            {
                MessageBox.Show("You have successfully registered guest patient!");
            }
            else
            {
                MessageBox.Show("Fill all data!");
            }

        }

    }
}
