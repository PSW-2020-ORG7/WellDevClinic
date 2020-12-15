using PSW_Wpf_app.ViewModel;
using System.Windows.Controls;

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for Pediatrics.xaml
    /// </summary>
    public partial class Pediatrics : UserControl
    {
        public Pediatrics()
        {
            InitializeComponent();
            DataContext = new BuildingsInformationViewModel();
        }
    }
}
