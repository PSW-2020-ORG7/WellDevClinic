﻿using System;
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
    /// Interaction logic for BuildingsInformationView.xaml
    /// </summary>
    public partial class BuildingsInformationView : Window
    {
        public BuildingsInformationView()
        {
            InitializeComponent();

        }

        private void OnSurgical(object sender, RoutedEventArgs e)
        {
            // DataContext = new BuildingsInformationViewModel();
            this.user2.Content = new Surgical();
        }

        private void OnMedicalCenter(object sender, RoutedEventArgs e)
        {
            //DataContext = new BuildingsInformationViewModel();
            this.user2.Content = new MedicalCenter();
        }

        private void OnPediatrics(object sender, RoutedEventArgs e)
        {
            // DataContext = new BuildingsInformationViewModel();
            this.user2.Content = new Pediatrics();
            

        }
    }
}
