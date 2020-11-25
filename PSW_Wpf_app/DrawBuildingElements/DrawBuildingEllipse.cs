using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using PSW_Wpf_app.Model;

namespace PSW_Wpf_app.DrawBuildingElements
{
    public class DrawBuildingEllipse
    {
        public Ellipse DrawEllipse(GraphicElement element)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = element.Width;
            ellipse.Height = element.Height;
            Canvas.SetLeft(ellipse, element.X);
            Canvas.SetTop(ellipse, element.Y);

            if (element.Type.Equals("Fountain"))
            {
                ellipse.Fill = new SolidColorBrush(Colors.LightGray);
            }
            else if (element.Type.Equals("Circle"))
            {
                ellipse.Fill = new SolidColorBrush(Colors.SteelBlue);
                ellipse.Name = element.Type;
            }

            return ellipse;
        }
    }
}
