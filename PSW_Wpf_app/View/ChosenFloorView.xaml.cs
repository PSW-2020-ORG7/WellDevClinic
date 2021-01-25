using System.Collections.Generic;
using System.Windows.Controls;
using PSW_Wpf_app.Model;
using PSW_Wpf_app.ViewModel;

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for ChosenFloorView.xaml
    /// </summary>
    public partial class ChosenFloorView : UserControl
    {
        public ChosenFloorView(string build, int floor)
        {
            InitializeComponent();
            DataContext = new ChoesenFloorViewModel(CanvasFloor, build, floor);
        }

        public ChosenFloorView(string build, int floor, List<FloorElement> rooms, string user, string username)
        {
            InitializeComponent();
            DataContext = new ChoesenFloorViewModel(CanvasFloor, build, floor, rooms, user, username);
        }
    }
}
