using PSW_Wpf_app.ViewModel;
using System.Windows;

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for SearchResultView.xaml
    /// </summary>
    public partial class SearchResultView : Window
    {
        public SearchResultView(string text)
        {
            InitializeComponent();
            DataContext = new SearchResultViewModel(text);
        }
    }
}
