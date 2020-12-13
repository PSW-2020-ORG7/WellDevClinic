using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;
using PSW_Wpf_app.Model;

namespace PSW_Wpf_app.ViewModel
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
       

