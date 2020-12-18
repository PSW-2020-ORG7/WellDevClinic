using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PSW_Wpf_app.Model;

namespace PSW_Wpf_app.Drawing
{
    public class DrawEllipseElementFloor
    {
        private Ellipse ellipse;
        private FloorElement floorElement;

        public DrawEllipseElementFloor(FloorElement floorElement)
        {
            this.floorElement = floorElement;
            ellipse = new Ellipse();
        }

        public Shape DrawEllipseElement(bool flag = false)
        {
            ellipse = new Ellipse();
            ellipse.Width = floorElement.Width;
            ellipse.Height = floorElement.Height;
            ellipse.Name = floorElement.Type;
            ellipse.Fill = new SolidColorBrush(Colors.Yellow);
            Canvas.SetLeft(ellipse, floorElement.X);
            Canvas.SetTop(ellipse, floorElement.Y);

            if (floorElement.Type.Equals("counter"))
                CustomizeCounter();

            if (flag)
            {
                CustomizeFoundRoom();
            }

            return ellipse;
        }

        public void CustomizeFoundRoom()
        {
            ellipse.Stroke = new SolidColorBrush(Colors.Red);
        }

        private void CustomizeCounter()
        {
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri(@"../../../Images/info.png", UriKind.Relative));
            ellipse.Fill = myBrush;

        }
    }
}
