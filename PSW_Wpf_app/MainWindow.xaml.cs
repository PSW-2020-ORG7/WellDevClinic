using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using PSW_Wpf_app.Model;
using PSW_Wpf_app.View;
using PSW_Wpf_app.ViewModel;

namespace PSW_Wpf_app
{

    public partial class MainWindow : Window
    {
        public List<string> names = new List<string>();

        List<GraphicElement> elements = new List<GraphicElement>();


        private List<FloorElement> foundRooms = new List<FloorElement>();
        private string user;
        private string Username { get; set; }
        public string User
        {
            get { return user; }
            set { user = value; }

        }
        public List<FloorElement> FoundRooms
        {
            get { return foundRooms; }
            set { foundRooms = value; }
        }


        public MainWindow(string role, string username)
        {

            InitializeComponent();
            user = role;
            Username = username;
            if (role == "patient")
            {
                Equipment_Drugs.Visibility = Visibility.Hidden;
                Map_Info.Visibility = Visibility.Hidden;
                Appointment.Visibility = Visibility.Hidden;
            }
            else if (role == "director")
            {
                Appointment.Visibility = Visibility.Hidden;
            }


            elements = ShapeViewModel.Read();
            foreach (GraphicElement e in elements)
            {
                names.Add(e.Name);
            }
            userControl.Content = new MainBuildingView();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (buildC.SelectedItem == null)
            {
                MessageBox.Show("You must choose building.");
            }
            else if (floorC.SelectedItem == null)
            {
                MessageBox.Show("You must choose floor.");
            }
            else
            {
                this.userControl.Content = new ChosenFloorView(((GraphicElement)buildC.SelectedItem).Name, int.Parse(floorC.SelectedItem.ToString()), FoundRooms, user, Username);
            }
        }

        private void Button_Click_HOME(object sender, RoutedEventArgs e)
        {
            this.userControl.Content = new MainBuildingView();
            FoundRooms = new List<FloorElement>();
        }

        private void OnMoreInfoClick(object sender, RoutedEventArgs e)
        {
            BuildingsInformationView buildingsInformationView = new BuildingsInformationView();
            buildingsInformationView.Show();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            if (SearchBuilding.Text == "")
            {
                MessageBox.Show("You must enter room for search.");
            }
            else
            {
                FoundRooms = new List<FloorElement>();

                SearchResultView searchResultView = new SearchResultView(SearchBuilding.Text);
                searchResultView.Show();

                SearchResultViewModel sw = (SearchResultViewModel)searchResultView.DataContext;
                FoundRooms = sw.SearchedObjectResults;
            }
        }

        private void ValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9a-zA-Z_]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Equipment_Drugs(object sender, RoutedEventArgs e)
        {

            EquipmentAndDrugsView equipmentDrugsView = new EquipmentAndDrugsView();
            equipmentDrugsView.Show();
        }

        private void Button_Appointment(object sender, RoutedEventArgs e)
        {
            AppointmentView appointment = new AppointmentView();
            appointment.Show();
        }


        private void EmergencyAppointment_Click(object sender, RoutedEventArgs e)
        {
            EmergencyAppointmentView emergencyAppointmentView = new EmergencyAppointmentView();
            emergencyAppointmentView.Show();
        }
            private void SpecialistAppointment_Click(object sender, RoutedEventArgs e)
            {
                SpecialistAppointmentView view = new SpecialistAppointmentView();
                view.ShowDialog();

            }

        private void RelocationAppointment_Click(object sender, RoutedEventArgs e)
        {
            RelocationEquipmentView view = new RelocationEquipmentView();
            view.Show();
        }

        private async void Shortcut_Click(object sender, RoutedEventArgs e)
        {
            long id =  await Client.WpfClient.GetMostVisitedRoom(Username);
            Room room = await Client.WpfClient.GetRoomById(id);
            MessageBox.Show("The most visited room is room -> "+room.RoomCode);
        }
    }
    
}
