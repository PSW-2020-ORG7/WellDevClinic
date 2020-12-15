using System.Windows.Controls;
using PSW_Wpf_app.ViewModel;

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for MainBuildings.xaml
    /// </summary>
    public partial class MainBuildingView : UserControl
    {

        public MainBuildingView()
        {
            InitializeComponent();
            DataContext = new MainBuildingsViewModel(CanvasBuilding);


        }
    }
}
