using PSW_Wpf_app.Model;
using System.Windows;

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for RoomStuffView.xaml
    /// </summary>
    public partial class RoomStuffView : Window
    {
        public RoomStuffView(FloorElement f)
        {
            
            InitializeComponent();
            userEqipmentAndDrugs.Content = new RoomOverviewView(f);
        }
    }
}
