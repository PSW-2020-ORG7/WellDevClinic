using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Model.Users;
using PSW_Wpf_secretary.Client;
using Secretary = PSW_Wpf_secretary.Client.Secretary;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public String Username { get; set; }

        public Login()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;

            var userController = app.UserController;
            PasswordBox passwordBox = FindName("password") as PasswordBox;
            try
            {
                UserLogIn userLogIn = new UserLogIn();
                userLogIn.Password = password.Password;
                userLogIn.Username = username.Text;
                Secretary user = await WpfSecretaryClient.GetUser(userLogIn);
                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
                this.Close();
            }
            catch (Exception exception)
            {
                TextBlock err = (TextBlock)FindName("ErrorMessage");
                err.Visibility = Visibility.Visible;
            }
        }
    }
}
