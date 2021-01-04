using PSW_Wpf_app.Client;
using PSW_Wpf_app.ViewModel;
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

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for RelocationEquipmentView.xaml
    /// </summary>
    public partial class RelocationEquipmentView : Window
    {
        RelocationEquipmentViewModel context = new RelocationEquipmentViewModel();

        public RelocationEquipmentView()
        {
            InitializeComponent();
            DataContext = context;

        }

        private void equipments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            context.LoadRoomByEquipment(((Equipment)equipments.SelectedItem).Id);

        }

        private void room_from_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Room room_from = (Room)rooms_from.SelectedItem;
            if (room_from != null)
                context.LoadRoom(room_from);
        }
    }
}
