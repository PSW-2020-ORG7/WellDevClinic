using PSW_Wpf_app.Client;
using PSW_Wpf_app.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for RoomOverviewView.xaml
    /// </summary>
    public partial class RoomOverviewView : UserControl
    {
        
        public RoomOverviewView(FloorElement f)
        {
            InitializeComponent();
            AdditionalInfo.Text = f.Info;
            this.DgDrug.ItemsSource = f.Drugs;
            this.DgEquipment.ItemsSource = f.Equipments;
        }
    }
}
