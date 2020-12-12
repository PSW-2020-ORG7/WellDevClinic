﻿using PSW_Wpf_app.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PSW_Wpf_app.ViewModel
{
    class AppointmentViewModel:BindableBase
    {
        BindingList<Doctor> doctors = new BindingList<Doctor>();

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
        public AppointmentViewModel()
        {
            // doctors = new BindingList<Doctor>();
            LoadDoctors();
           
           // LoadDoctors();
        }

        private async void LoadDoctors()
        {
            Doctors = new BindingList<Doctor>(await WpfClient.GetAllDoctors());
            foreach (Doctor d in doctors)
            {
                name.Add(d.FirstName);
                
            }
        }
    }
}
