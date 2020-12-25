using PSW_Wpf_app.Client;
using PSW_Wpf_app.ViewModel;
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
    /// Interaction logic for SpecialistAppointmentView.xaml
    /// </summary>
    public partial class SpecialistAppointmentView : Window
    {

        SpecialistAppointmentViewModel context = new SpecialistAppointmentViewModel();

        public SpecialistAppointmentView()
        {
            InitializeComponent();
            DataContext = context;
        }
        private async void SearchPeriods_Click(object sender, RoutedEventArgs e)
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
                List<ExaminationDTO> exams = await WpfClient.FindTerms(businessDayDTO);

                //nova prazna lista koju cemo bajnovati na datagrid
                List<ExaminationDTO> final = new List<ExaminationDTO>();
                //prolazimo krooz sve termine
                foreach (ExaminationDTO item in exams)
                {
                    //zato sto u terminu imas roomId
                    // Room room = await WpfClient.GetRoomById(item.Room.Id);
                    if (item.Room.Equipment_inventory.Find(x => x.Equipment.Name == ((Equipment)EquipmentBox.SelectedItem).Name) != null)
                    {
                        final.Add(item);
                    }


                }
                if (final.Count == 0)
                {
                    MessageBox.Show("There is no selected equipment in this room. Choose a priority!!");

                }
                scheduleExaminationsGrid.ItemsSource = final;
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
            else if (PriorityBox.SelectedIndex == 2)
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
             else
             {
                 if (Picker.SelectedDate == null || Picker2.SelectedDate == null)
                     return;

             }
        }


        private void OnChangeSpeciality(object sender, SelectionChangedEventArgs e)
        {
            context.LoadDoctors(((Speciality)specs.SelectedItem).Name);
        }


        private async void Schedule_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = scheduleExaminationsGrid.SelectedItem;

            if (selectedItem == null)
            {
                return;
            }

            ErrorSchedule.Foreground = Brushes.Green;
            ExaminationDTO scheduleExam = (ExaminationDTO)selectedItem;

            ErrorSchedule.Text = "You have successfully scheduled an examination!";

            Doctor doctor = scheduleExam.Doctor;
            AppointmentViewModel a = new AppointmentViewModel();
            List<Patient> p = (List<Patient>)await WpfClient.GetAllPatient();
            Patient patient = (Patient)PatientForExaminations.SelectedItem;


            Period period = new Period();
            period.StartDate = scheduleExam.Period.StartDate;
            period.EndDate = scheduleExam.Period.EndDate;

            ExaminationDTO ex = new ExaminationDTO(doctor, period, patient);

            Examination examination = (Examination)await WpfClient.NewExamination(ex);

            if (examination != null)
            {
                MessageBox.Show("Appointment is scheduled!");
            }

        }

        private void scheduleExaminationsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
