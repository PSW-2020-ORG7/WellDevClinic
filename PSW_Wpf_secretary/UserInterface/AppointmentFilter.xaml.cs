﻿using System;
using System.Collections.Generic;
using System.Windows;
using Model.Director;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for AppointmentFilter.xaml
    /// </summary>
    public partial class AppointmentFilter : Window
    {
        public static int FromDay { get; set; }
        public static int ToDay { get; set; }
        public static int FromMonth { get; set; }
        public static int ToMonth { get; set; }
        public static int FromYear { get; set; }
        public static int ToYear { get; set; }
        public static int FromHour { get; set; }
        public static int ToHour { get; set; }
        public static int FromMinute { get; set; }
        public static int ToMinute { get; set; }
        public List<Patient> Patients { get; set; }
        public Patient SelectedPatient { get; set; }
        public List<Room> Rooms { get; set; }
        public Room SelectedRoom { get; set; }
        public List<Doctor> Doctors { get; set; }
        public Doctor SelectedDoctor { get; set; }

        public AppointmentFilter(List<Patient> patients)
        {
            InitializeComponent();
            this.DataContext = this;
            FromDay = ToDay = DateTime.Now.Day;
            FromMonth = ToMonth = DateTime.Now.Month;
            FromYear = ToYear = DateTime.Now.Year;
            FromHour = ToHour = DateTime.Now.Hour;
            FromMinute = ToMinute = DateTime.Now.Minute;

            App app = Application.Current as App;

            Rooms.Insert(0, null);
            SelectedRoom = Rooms[0];

            Patients.Insert(0, null);
            SelectedPatient = Patients[0];

            Doctors.Insert(0, null);
            SelectedDoctor = Doctors[0];
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            ExaminationDTO examinationFilter = new ExaminationDTO(SelectedDoctor, SelectedRoom, new Period(new DateTime(FromYear, FromMonth, FromDay, FromHour, FromMinute, 0), new DateTime(ToYear, ToMonth, ToDay, ToHour, ToMinute, 0)), SelectedPatient);
            MainWindow.FilterExaminations(examinationFilter);
            CloseWindow(sender, e);
        }
    }
}
