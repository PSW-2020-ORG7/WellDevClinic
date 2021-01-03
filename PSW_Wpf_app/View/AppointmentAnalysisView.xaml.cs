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
    /// Interaction logic for AppointmentAnalysisView.xaml
    /// </summary>
    public partial class AppointmentAnalysisView : Window
    {
        EmergencyAppointmentViewModel context;
        public AppointmentAnalysisView(double dilayMinutes, ExaminationDTO examination)
        {
            InitializeComponent();

            minutes.Text = (dilayMinutes).ToString();
            List<ExaminationDTO> examination1 = new List<ExaminationDTO>();
            examination1.Add(examination);
            analysisData.ItemsSource = examination1;

        }



        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
