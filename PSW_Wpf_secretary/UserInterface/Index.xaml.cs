using System.Windows;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Window
    {
        public Index()
        {
            InitializeComponent();
            CreateArticles();
        }

        private void CreateArticles()
        {
            App app = Application.Current as App;
        }

        private void OpenLoginDialog(object sender, RoutedEventArgs e)
        {
            Login loginDialog = new Login();
            loginDialog.Show();
            this.Close();
        }
    }
}
