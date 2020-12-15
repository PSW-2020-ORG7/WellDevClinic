using PSW_Wpf_app.ViewModel;
using System.Windows.Controls;

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for DrugsView.xaml
    /// </summary>
    public partial class DrugsView : UserControl
    {
        public DrugsView()
        {
            InitializeComponent();
            DataContext = new EquipmentAndDrugsViewModel();
        }
    }
}
