using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_director.Utility
{
    class ShortcutData
    {
        public String Shortcut { get; set; }
        public String Description { get; set; }

        public ShortcutData(string shortcut, string description)
        {
            Shortcut = shortcut;
            Description = description;
        }
    }
}
