using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model
{
    class RelocationEquipmentDTO
    {

        private string room_from;
        private string room_to;
        private string equip_name;
        private DateTime date;
        private List<long> renovations_id;

        public List<long> Renovations_id
        {
            get { return renovations_id; }
            set { renovations_id = value; }
        }
        public string Room_from
        {
            get { return room_from; }
            set { room_from = value; }
        }


        public string Room_to
        {
            get { return room_to; }
            set { room_to = value; }
        }

        public string Equip_name
        {
            get { return equip_name; }
            set { equip_name = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public RelocationEquipmentDTO()
        {
            renovations_id = new List<long>();
        }
    }
}
