using PSW_Wpf_app.Client;
using PSW_Wpf_app.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PSW_Wpf_app.ViewModel
{
    class AppointmentViewModel:BindableBase
    {
        BindingList<Doctor> doctors = new BindingList<Doctor>();
        BindingList<Patient> patients = new BindingList<Patient>();

        private BindingList<string> name = new BindingList<string>();
        public BindingList<string> Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }



        public BindingList<Doctor> Doctors
        {
            get
            {
                return doctors;
            }
            set
            {
                doctors = value;
                OnPropertyChanged("Doctors");
            }

        }

        public BindingList<Patient> Patients
        {
            get
            {
                return patients;
            }
            set
            {
                patients = value;
                OnPropertyChanged("Patients");
            }

        }
        public AppointmentViewModel()
        {
            LoadDoctors();
            LoadPatients();
        }

        private async void LoadDoctors()
        {
            Doctors = new BindingList<Doctor>(await WpfClient.GetDoctorsBySpeciality("general practice"));
            foreach (Doctor d in doctors)
            {
                name.Add(d.Person.FirstName);
               
                
            }
        }

        private async void LoadPatients()
        {
            Patients = new BindingList<Patient>(await WpfClient.GetAllPatient());
            
        }
    }
}
