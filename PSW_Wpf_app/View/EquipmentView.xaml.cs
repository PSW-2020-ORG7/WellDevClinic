using PSW_Wpf_app.ViewModel;
using System.Windows.Controls;

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for EquipmentView.xaml
    /// </summary>
    public partial class EquipmentView : UserControl
    {
        public EquipmentView()
        {
            InitializeComponent();
            DataContext = new EquipmentAndDrugsViewModel();
        }
    }
}
