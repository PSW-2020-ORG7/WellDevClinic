using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model
{
    public class Ingredient
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Ingredient() { }
    }
}
