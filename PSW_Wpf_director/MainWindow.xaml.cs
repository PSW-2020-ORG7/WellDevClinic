using bolnica.Controller;
using Model.Users;
using PSW_Wpf_director.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PSW_Wpf_director
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IDirectorController directorController;
        private IUserController userController;

        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;


            var app = Application.Current as App;
            directorController = app.authorityDirector;
            userController = app.UserController;
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if (TxtBoxKorisnickoIme.Text.Equals("") || lozinka.Password.Equals(""))
            {
                labelError.Content = "Unesite korisnicko ime i lozinku!";
                labelError.Visibility = Visibility.Visible;
            }
            try
            {
                Director director = await WpfDirectorClient.GetUser(TxtBoxKorisnickoIme.Text, lozinka.Password);
                bool selected = (bool)stayLoggedIn.IsChecked;
                if (selected)
                {

                    string path;
                    path = @"../../../../PSW_Wpf_director/Resources/LoggedIn/config.txt";

                    File.WriteAllText(path, "true");
                }
                else
                {
                    string path;
                    path = @"../../../../PSW_Wpf_director/Resources/LoggedIn/config.txt";

                    File.WriteAllText(path, "false");
                }

                DashboardWindow dashBoard = new DashboardWindow(director);
                dashBoard.director = director;
                dashBoard.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                dashBoard.Show();
                this.Close();

            }
            catch
            {
                labelError.Content = "Neispravno korisnicko ime/lozinka!";
                labelError.Visibility = Visibility.Visible;
            }

        }

        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                button_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
