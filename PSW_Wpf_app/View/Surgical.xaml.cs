using PSW_Wpf_app.ViewModel;
using System.Windows.Controls;

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Surgical : UserControl
    {
        public Surgical()
        {
            InitializeComponent();
            DataContext = new BuildingsInformationViewModel();
        }

       
    }
}
