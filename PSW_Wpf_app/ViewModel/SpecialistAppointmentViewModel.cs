using PSW_Wpf_app.Client;
using PSW_Wpf_app.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PSW_Wpf_app.ViewModel
{
    class SpecialistAppointmentViewModel : BindableBase
    {

        BindingList<Doctor> doctors = new BindingList<Doctor>();
        BindingList<Speciality> specialities = new BindingList<Speciality>();
        BindingList<Patient> patients = new BindingList<Patient>();
        BindingList<Equipment> equipments = new BindingList<Equipment>();



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

        public BindingList<Speciality> Specialities
        {
            get
            {
                return specialities;
            }
            set
            {
                specialities = value;
                OnPropertyChanged("Specialities");
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

        public BindingList<Equipment> Equipments
        {
            get
            {
                return equipments;
            }
            set
            {
                equipments = value;
                OnPropertyChanged("Equipments");
            }

        }

        public SpecialistAppointmentViewModel()
        {
            LoadPatients();
            LoadSpecialities();
            LoadEquipment();
            //LoadDoctors();
        }

        public async void LoadSpecialities()
        {
            List<Speciality> list = await WpfClient.GetAllSpeciality();
            list.Remove(list.Find(x => x.Name == "general practice"));
            Specialities = new BindingList<Speciality>(list);
        }
        public async void LoadDoctors(string speciality)
        {
            Doctors = new BindingList<Doctor>(await WpfClient.GetDoctorsBySpeciality(speciality));
           
        }
        private async void LoadPatients()
        {
            Patients = new BindingList<Patient>(await WpfClient.GetAllPatient());

        }

        private async void LoadEquipment()
        {
            Equipments = new BindingList<Equipment>(await WpfClient.GetAllEquipment());
        }
    }
}
