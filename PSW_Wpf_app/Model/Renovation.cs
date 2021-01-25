using System;
using System.ComponentModel;

namespace PSW_Wpf_app.Model
{
    public enum RenovationStatus
    {
        [Description("U toku")]
        Traje,
        [Description("Zavrseno")]
        Zavrseno,
        [Description("Zakazano")]
        Zakazano,
        [Description("Otkazano")]
        Otkazano,

    }
    public class Renovation
    {
        public long Id { get; set; }
        public Period Period { get; set; }
        public String Description { get; set; }
        public Room Room { get; set; }
        public RenovationStatus RenovationStatus { get; set; }

        
        public Renovation()
        {
        }

    }
}
