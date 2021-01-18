using PSW_Wpf_app.Client;
using PSW_Wpf_app.Model;
using PSW_Wpf_app.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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

        private bool DoctorIsSelected()
        {
            return DoctorsForExaminations.SelectedItem != null;
        }

        private bool PriorityIsNone()
        {
            return PriorityBox.SelectedIndex == 0;
        }

        private bool PriorityIsDoctor()
        {
            return PriorityBox.SelectedIndex == 1;
        }

        private bool PriorityIsDate()
        {
            return PriorityBox.SelectedIndex == 2;
        }


        private bool DateIsSelected()
        {
            if (Picker.SelectedDate != null)
                if (Picker2.SelectedDate != null)
                    return true;
            return false;
        }

        private async void SearchAvailablePeriods(PriorityType priorityType)
        {
            Doctor doctor = (Doctor)DoctorsForExaminations.SelectedItem;
            

            PriorityType priority = priorityType;
            Period period = new Period();
            period.StartDate = DateTime.Parse(Picker.Text);
            period.EndDate = DateTime.Parse(Picker2.Text);

            BusinessDayDTO businessDayDTO = new BusinessDayDTO(doctor, period, priority);
            List<ExaminationDTO> exams = await WpfClient.FindTerms(businessDayDTO);

            List<ExaminationDTO> final = new List<ExaminationDTO>();
            foreach (ExaminationDTO item in exams)
            {
                if (item.Room.EquipmentStatistic.Find(x => x.Equipment.Name == ((Equipment)EquipmentBox.SelectedItem).Name) != null)
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

        private async void SearchPeriods_Click(object sender, RoutedEventArgs e)
        {
            if (!DoctorIsSelected())
                return;

            if (!DateIsSelected())
                return;

            if (PriorityIsNone())
            {
                SearchAvailablePeriods(PriorityType.NoPriority);
            }
            else if (PriorityIsDoctor())
            {
                SearchAvailablePeriods(PriorityType.Doctor);
            }
            else if (PriorityIsDate())
            {
                SearchAvailablePeriods(PriorityType.Date);
            }
        }


        private async void Schedule_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = scheduleExaminationsGrid.SelectedItem;

            if (selectedItem == null)
            {
                return;
            }

            ExaminationDTO scheduleExam = (ExaminationDTO)selectedItem;


            Doctor doctor = scheduleExam.Doctor;
            AppointmentViewModel a = new AppointmentViewModel();
            List<Patient> p = (List<Patient>)await WpfClient.GetAllPatient();
            Patient patient = (Patient)PatientForExaminations.SelectedItem;

            Period period = new Period();
            period.StartDate = scheduleExam.Period.StartDate;
            period.EndDate = scheduleExam.Period.EndDate;


            UpcomingExamination ex = new UpcomingExamination(doctor, period, patient);

            UpcomingExamination examination = (UpcomingExamination)await WpfClient.NewExamination(ex);

            if (examination != null)
            {
                MessageBox.Show("Appointment is scheduled!");
            }

        }

        private void OnChangeSpeciality(object sender, SelectionChangedEventArgs e)
        {
            context.LoadDoctors(((Speciality)specs.SelectedItem).Name);
        }


        private void scheduleExaminationsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
