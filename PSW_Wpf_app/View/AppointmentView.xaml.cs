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
    /// Interaction logic for AppointmentView.xaml
    /// </summary>
    public partial class AppointmentView : Window
    {
        
       
        public AppointmentView()
        {
            InitializeComponent();
        }
        private async void SearchPeriods(object sender, RoutedEventArgs e)
        {


            if (DoctorsForExaminations.SelectedItem == null)
                return;
            if (PriorityBox.SelectedIndex == 0)
            {
                if (Picker.SelectedDate == null)
                    return;

                
                DoctorDTO d = (DoctorDTO)DoctorsForExaminations.SelectedItem;
                Doctor doctor = new Doctor() { Id = d.Id, FirstName = d.Name, LastName = d.Surname };

                string priority = "noPriority";
                Period period = new Period();
                period.StartDate = DateTime.Parse(Picker.Text);
                BusinessDayDTO businessDayDTO = new BusinessDayDTO(doctor, period, priority);
                businessDayDTO.PatientScheduling = true;
                scheduleExaminationsGrid.ItemsSource = await WpfClient.FindTerms(businessDayDTO);
               
            }
            else if (PriorityBox.SelectedIndex == 1)
            {
                if (Picker.SelectedDate == null || Picker2.SelectedDate == null)
                    return;

                DoctorDTO d = (DoctorDTO)DoctorsForExaminations.SelectedItem;
                Doctor doctor = new Doctor() { Id = d.Id, FirstName = d.Name, LastName = d.Surname };

                string priority = "doctor";
                Period period = new Period();
                period.StartDate = DateTime.Parse(Picker.Text);
                period.EndDate = DateTime.Parse(Picker2.Text);
                BusinessDayDTO businessDayDTO = new BusinessDayDTO(doctor, period, priority);
                businessDayDTO.PatientScheduling = true;
                scheduleExaminationsGrid.ItemsSource = await WpfClient.FindTerms(businessDayDTO);

            }
            else
            {
                if (Picker.SelectedDate == null || Picker2.SelectedDate == null)
                    return;

              
            }
        }

        private async void ScheduleExamination(object sender, RoutedEventArgs e)
        {
            var selectedItem = scheduleExaminationsGrid.SelectedItem;

            if (selectedItem == null)
            {
                return;
            }

            ErrorSchedule.Foreground = Brushes.Green;
            ExaminationDTO scheduleExam = (ExaminationDTO)selectedItem;

            ErrorSchedule.Text = "You have successfully scheduled an examination!";

            Doctor doctor= scheduleExam.Doctor;
            long doctorId = doctor.Id;
            AppointmentViewModel a = new AppointmentViewModel();
            List<Patient> p = (List<Patient>)await WpfClient.GetAllPatient();
            Patient patient = (Patient)PatientForExaminations.SelectedItem;
            long patientId = 0;
            foreach (Patient pt in p)
            {
                if(pt.Username.Equals(patient.Username))
                    patientId = pt.Id;
            }
            
            
            string period;
            

            period = scheduleExam.StartDate.ToString() + "S" + scheduleExam.EndDate.ToString();


            ExaminationIdsDTO ex = new ExaminationIdsDTO(doctorId, period,patientId );

            Examination examination = (Examination)await WpfClient.NewExamination(ex);

            if (examination == null)
            {
                MessageBox.Show("Appointment is scheduled!");
            }

        }


    }
}
