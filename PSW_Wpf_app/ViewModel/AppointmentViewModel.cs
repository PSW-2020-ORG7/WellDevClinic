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
        public AppointmentViewModel()
        {
            LoadDoctors();
          
        }

        private async void LoadDoctors()
        {
            Doctors = new BindingList<DoctorDTO>(await WpfClient.GetDoctorsBySpeciality("general practice"));
            foreach (DoctorDTO d in doctors)
            {
                name.Add(d.Name);
               
                
            }
        }
    }
}
