using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PSW_Wpf_app.Model;

namespace PSW_Wpf_app.Drawing
{
    public class DrawRectangleElementFloor
    {
        private Rectangle rectangle;
        private VisualBrush brush;
        private StackPanel panel;
        private TextBlock name;
        FloorElement floorElement;
        public DrawRectangleElementFloor(FloorElement floorElement)
        {
            rectangle = new Rectangle();
            brush = new VisualBrush();
            panel = new StackPanel();
            name = new TextBlock();
            this.floorElement = floorElement;
        }
        public Shape DrawRectangleElement(bool flag = false)
        {
            name.Text = floorElement.Name;
            name.FontSize = 5;
            name.Margin = new Thickness(8);
            panel.Children.Add(name);
            brush.Visual = panel;
            rectangle.Fill = brush;

            rectangle.Width = floorElement.Width;
            rectangle.Height = floorElement.Height;
            rectangle.Stroke = new SolidColorBrush(Colors.Black);

            Canvas.SetLeft(rectangle, floorElement.X);
            Canvas.SetTop(rectangle, floorElement.Y);

            if (floorElement.Type.Equals("room"))
                CustomizeRoom();
            else if (floorElement.Type.Equals("restroom"))
                CustomizeRestroom();
            else if (floorElement.Type.Equals("storageRoom"))
                CustomizeStorageroom();
            else if (floorElement.Type.Equals("elevator"))
                CustimizeElevator();
            else if (floorElement.Type.Equals("stairs"))
                CustomizeStairs();
            else if (floorElement.Type.Equals("door"))
                CustomizeDoor();
            else if (floorElement.Type.Equals("waitingRoom"))
                CustomizeWaitingRoom();
            else if (floorElement.Type.Equals("base"))
                CustomizeBase();


            if (flag)
            {
                CustomizeFoundRoom();
            }
            return rectangle;
        }

        public void CustomizeFoundRoom()
        {
            rectangle.Stroke = new SolidColorBrush(Colors.Red);
            rectangle.StrokeThickness = 4;

        }

        private void CustomizeRoom()
        {
            panel.Background = new SolidColorBrush(Colors.CadetBlue);
            rectangle.Name = floorElement.Name;
        }

        private void CustomizeRestroom()
        {
            panel.Background = new SolidColorBrush(Colors.LightSteelBlue);
            rectangle.Name = floorElement.Name;
        }

        private void CustomizeStorageroom()
        {
            panel.Background = new SolidColorBrush(Colors.Tan);
            rectangle.Name = floorElement.Name;
        }

        private void CustimizeElevator()
        {
            panel.Background = new SolidColorBrush(Colors.LightGray);
            rectangle.Name = floorElement.Name;
        }

        private void CustomizeStairs()
        {
            panel.Background = new SolidColorBrush(Colors.Gray);
            rectangle.Name = floorElement.Name;
        }

        private void CustomizeDoor()
        {
            rectangle.Fill = new SolidColorBrush(Colors.Black);
            name.Text = "";
        }

        private void CustomizeWaitingRoom()
        {
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../Images/waiting-room.png", UriKind.Relative));
            rectangle.Fill = myBrush;
            name.Text = "";
        }

        private void CustomizeBase()
        {
            name.Text = "";
        }

    }
}
