using bolnica.Controller;
using Model.Director;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace PSW_Wpf_director
{
    /// <summary>
    /// Interaction logic for RoomTypeWindow.xaml
    /// </summary>
    public partial class RoomTypeWindow : Window
    {
        private readonly IRoomTypeController _roomTypeController;
        private readonly IRoomController _roomController;

        public RoomTypeWindow()
        {
            InitializeComponent();

            var app = Application.Current as App;
            _roomTypeController = app.authorityRoomType;
            _roomController = app.authorityRoom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<RoomType> roomTypes = new List<RoomType>();
            roomTypes = _roomTypeController.GetAll().ToList();

            ObservableCollection<RoomType> temp = new ObservableCollection<RoomType>(roomTypes);

            listViewRoomTypes.ItemsSource = temp;
            listViewRoomTypes.DisplayMemberPath = "Name";
            listViewRoomTypes.SelectedValuePath = "Id";
            listViewRoomTypes.SelectedValue = "2";


        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            AddRoomType dialog = new AddRoomType(listViewRoomTypes);
            dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dialog.ShowDialog();
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            if (listViewRoomTypes.SelectedItem != null)
            {
                AddRoomType dialog = new AddRoomType(listViewRoomTypes, (RoomType)listViewRoomTypes.SelectedItem);
                dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                dialog.ShowDialog();



            }
            else
            {
                string messageBoxText = "Morate selektovati tip prostorije da biste ga izmenili!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (listViewRoomTypes.SelectedItem != null)
            {
                RoomType roomType = (RoomType)listViewRoomTypes.SelectedItem;

                string messageBoxText = "Da li ste sigurni da zelite da obrisete ti prostorije pod nazivom " + roomType.Name + "?\nBrisanje tipa prostorije ce izbrisati i sve prostorije te vrste!";
                string caption = "Potvrda brisanja";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Question;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                if (result == MessageBoxResult.Yes)
                {
                    _roomTypeController.Delete((RoomType)listViewRoomTypes.SelectedItem);


                    listViewRoomTypes.ItemsSource = null;

                    List<RoomType> roomTypes = new List<RoomType>();
                    roomTypes = _roomTypeController.GetAll().ToList();

                    ObservableCollection<RoomType> temp = new ObservableCollection<RoomType>(roomTypes);

                    listViewRoomTypes.ItemsSource = temp;
                    listViewRoomTypes.DisplayMemberPath = "Name";
                    listViewRoomTypes.SelectedValuePath = "Id";
                    listViewRoomTypes.SelectedValue = "2";
                }
            }
            else
            {
                string messageBoxText = "Morate selektovati tip prostorije da biste ga izbrisali!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                this.Close();
            }
            else if (e.Key == System.Windows.Input.Key.N && Keyboard.Modifiers == ModifierKeys.Control)
            {
                addRoomTypeBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.E && Keyboard.Modifiers == ModifierKeys.Control)
            {
                editRoomTypeBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }
    }
}
