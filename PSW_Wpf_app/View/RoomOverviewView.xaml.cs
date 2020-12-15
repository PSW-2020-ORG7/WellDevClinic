using PSW_Wpf_app.Model;
using System.Windows.Controls;

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
