using PSW_Wpf_app.ViewModel;
using System.Windows.Controls;

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for MedicalCenter.xaml
    /// </summary>
    public partial class MedicalCenter : UserControl
    {
        public MedicalCenter()
        {
            InitializeComponent();
            DataContext = new BuildingsInformationViewModel();
        }
    }
}
