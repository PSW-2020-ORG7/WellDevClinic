using PSW_Wpf_app.Client;
using PSW_Wpf_app.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;

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

                PriorityType priority = PriorityType.NoPriority;
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

                PriorityType priority = PriorityType.Doctor;
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
                DoctorDTO d = (DoctorDTO)DoctorsForExaminations.SelectedItem;
                Doctor doctor = new Doctor() { Id = d.Id, FirstName = d.Name, LastName = d.Surname };

                PriorityType priority = PriorityType.Date;
                Period period = new Period();
                period.StartDate = DateTime.Parse(Picker.Text);
                period.EndDate = DateTime.Parse(Picker2.Text);
                BusinessDayDTO businessDayDTO = new BusinessDayDTO(doctor, period, priority);
                businessDayDTO.PatientScheduling = true;
                scheduleExaminationsGrid.ItemsSource = await WpfClient.FindTerms(businessDayDTO);

            }
        }

        public static long RomId = -1;

        private async void ScheduleExamination(object sender, RoutedEventArgs e)
        {
            var selectedItem = scheduleExaminationsGrid.SelectedItem;

            if (selectedItem == null)
            {
                return;
            }

            ExaminationDTO scheduleExam = (ExaminationDTO)selectedItem;

            
            Doctor doctor= scheduleExam.Doctor;
            AppointmentViewModel a = new AppointmentViewModel();
            List<Patient> p = (List<Patient>)await WpfClient.GetAllPatient();
            Patient patient = (Patient)PatientForExaminations.SelectedItem;
            
            Period period =  new Period();
            period.StartDate = scheduleExam.Period.StartDate;
            period.EndDate = scheduleExam.Period.EndDate;


            ExaminationDTO ex = new ExaminationDTO(doctor, period, patient);

            Examination examination = (Examination)await WpfClient.NewExamination(ex);

            if (examination != null)
            {
                MessageBox.Show("Appointment is scheduled!");
                GetRoomId(doctor.Id);

            }

        }
        private async void GetRoomId(long id)
        {
            BusinessDayDTO buss = await WpfClient.GetBussinessdayByDoctor(id);
            RomId = buss.RoomId;
        }

    }
}
