using PSW_Wpf_app.Client;
using PSW_Wpf_app.Model;
using System;
using System.Windows.Controls;

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for RoomOverviewView.xaml
    /// </summary>
    public partial class RoomOverviewView : UserControl
    {
        
        public RoomOverviewView(FloorElement f)
        {
            InitializeComponent();
            AdditionalInfo.Text = f.Info;
            this.DgDrug.ItemsSource = f.Drugs;
            long id = Convert.ToInt64(f.RoomId);
            LoadRoom(id);
            
           
        }

        public async void LoadRoom(long id)
        {
            Room room = await WpfClient.GetRoomById(id);
            this.DgEquipment.ItemsSource = room.Equipment_inventory;
        }
    }
}
