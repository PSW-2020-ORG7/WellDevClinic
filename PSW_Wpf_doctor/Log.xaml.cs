﻿using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PSW_Wpf_doctor
{
    public partial class Log : Window
    {
        public String Username { get; set; }
        public Log()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;

            PasswordBox passwordBox = FindName("password_text") as PasswordBox;
            try
            {
                Doctor user = (Doctor)app.UserController.Login(Username, passwordBox.Password);
                if (user != null)
                {
                    SideBar sideBar = new SideBar((Doctor)user);
                    sideBar.Show();
                    this.Close();
                }
                else
                {
                    obavestiGreska.Visibility = Visibility.Visible;
                }
            }
            catch (Exception exception)
            {
                obavestiGreska.Visibility = Visibility.Visible;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWin.Show();
        }
    }
}
