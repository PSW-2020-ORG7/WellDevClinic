using PSW_Wpf_app.Client;
using PSW_Wpf_app.Model;
using PSW_Wpf_app.ViewModel;
using System;
using System.Collections.Generic;
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

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for MergedRoomInfoView.xaml
    /// </summary>
    public partial class MergedRoomInfoView : Window
    {

        long roomId;
        long mapRoomId;
        DateTime date;
        RenovationFlowViewModel renovationFlow = new RenovationFlowViewModel();
        public MergedRoomInfoView(long roomId, DateTime date, long mapRoomId)
        {

            InitializeComponent();
            this.roomId = roomId;
            this.date = date;
            this.mapRoomId = mapRoomId;
        }

        public async Task<Renovation> LoadExactRenovation(long roomId, DateTime date)
        {
            List<Renovation> renovations = await WpfClient.GetAllRenovation();
            Renovation renovation = new Renovation();
            foreach(Renovation r in renovations)
            {
                if (r.Room.Id.Equals(roomId) && r.Period.StartDate.Date.Equals(date.Date))
                {
                    r.Description = roomDescription.Text + "/" + roomName.Text;
                    renovation = r;
                }
            }
            return renovation;
        }
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            Renovation renovation = await LoadExactRenovation(roomId, date);
            WpfClient.EditRenovation(renovation);
            renovationFlow.RelocateEquipment(renovation, roomId, date);
            renovationFlow.RelocateEquipment(renovation, mapRoomId, date);
            MessageBox.Show("After renovation is finished, information will be applied !");
        }
    }
}
