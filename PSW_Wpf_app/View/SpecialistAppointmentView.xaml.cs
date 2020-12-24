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


                Period period = new Period();
                period.StartDate = DateTime.Parse(Picker.Text);
                BusinessDayDTO businessDayDTO = new BusinessDayDTO(doctor, period);
                businessDayDTO.PatientScheduling = true;
                scheduleExaminationsGrid.ItemsSource = await WpfClient.FindTerms(businessDayDTO);

            }
            else if (PriorityBox.SelectedIndex == 1)
            {
                if (Picker.SelectedDate == null || Picker2.SelectedDate == null)
                    return;

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

    }
}
