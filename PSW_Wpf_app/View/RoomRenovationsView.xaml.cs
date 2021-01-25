using PSW_Wpf_app.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for RoomRenovationsView.xaml
    /// </summary>
    public partial class RoomRenovationsView : UserControl
    {
        private FloorElement floor;

        public RoomRenovationsView(FloorElement floor)
        {
            InitializeComponent();
            this.floor = floor;
            LoadRenovations(floor.RoomId);
        }

        private void AdvancedRenovation_Click(object sender, RoutedEventArgs e)
        {
            RoomAdvancedRenovationView view = new RoomAdvancedRenovationView(floor);
            view.Show();
        }

        private void BasicRenovationClick(object sender, RoutedEventArgs e)
        {
            BasicRenovationView basic = new BasicRenovationView(floor.RoomId);
            basic.ShowDialog();
        }

        public async void LoadRenovations(long roomId)
        {
            List<Renovation> renovations = await Client.WpfClient.GetAllRenovation();
            BindingList<Renovation> roomRenovations = new BindingList<Renovation>();
            foreach(Renovation r in renovations)
            {
                if (r.Room.Id.Equals(roomId))
                    roomRenovations.Add(r);
            }
            roomRenovation.ItemsSource = roomRenovations;
        }
    }
}
