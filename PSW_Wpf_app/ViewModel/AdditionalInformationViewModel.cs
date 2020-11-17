using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class AdditionalInformationViewModel
    {

        public static void openInfo(object sender, MouseButtonEventArgs e)
        {
            var mouseWasDownOn = e.Source as FrameworkElement;
            List<GraphicElement> elements = ShapeViewModel.Read();
            if (mouseWasDownOn != null)
            {
                string elementName = mouseWasDownOn.Name;
                Console.WriteLine(elementName);
                foreach (GraphicElement graphicElement in elements)
                {
                    if (elementName.Equals(graphicElement.Name))
                    {
                        MessageBox.Show(string.Format("{0}\n", graphicElement.Info));
                    }

                }

            }
        }
    }
}
       

