using PSW_Wpf_app.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PSW_Wpf_app.ViewModel
{
    class AppointmentViewModel:BindableBase
    {
        BindingList<DoctorDTO> doctors = new BindingList<DoctorDTO>();
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



        public BindingList<DoctorDTO> Doctors
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
            Doctors = new BindingList<DoctorDTO>(await WpfClient.GetDoctorsBySpeciality("general practice"));
            foreach (DoctorDTO d in doctors)
            {
                name.Add(d.Name);
               
                
            }
        }

        private async void LoadPatients()
        {
            Patients = new BindingList<Patient>(await WpfClient.GetAllPatient());
            
        }
    }
}
