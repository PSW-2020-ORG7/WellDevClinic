using bolnica.Controller;
using Model.Director;
using PSW_Wpf_director.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PSW_Wpf_director
{
    /// <summary>
    /// Interaction logic for RoomEquipmentDialog.xaml
    /// </summary>
    public partial class RoomEquipmentDialog : Window
    {
        private Room _selectedRoom;
        private readonly IRoomController _roomController;
        public RoomEquipmentDialog(Room selectedRoom)
        {
            InitializeComponent();
            _selectedRoom = selectedRoom;

            var app = Application.Current as App;
            _roomController = app.authorityRoom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            List<RoomEquipment> lista_opreme = new List<RoomEquipment>();
            foreach (KeyValuePair<Equipment, int> pair in _roomController.Get(_selectedRoom.Id).Equipment_inventory)
            {
                lista_opreme.Add(new RoomEquipment(pair.Key.Name, pair.Value));
            }

            this.lista.ItemsSource = lista_opreme;

        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                this.Close();
            }
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
