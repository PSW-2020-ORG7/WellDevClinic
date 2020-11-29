using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PSW_Wpf_app.Model;
using PSW_Wpf_app.ViewModel;

namespace PSW_Wpf_app.DrawBuildingElements
{
    public class DrawBuildingRectangle
    {
        public Rectangle DrawRectangle(GraphicElement element)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Name = element.Name;
            rectangle.Width = element.Width;
            rectangle.Height = element.Height;

            VisualBrush brush = new VisualBrush();
            StackPanel panel = new StackPanel();
            panel.Background = new SolidColorBrush(Colors.CadetBlue);
            TextBlock objectName = new TextBlock();
            objectName.Text = element.Name;
            objectName.FontSize = 7;
            objectName.Margin = new Thickness(8);

            panel.Children.Add(objectName);
            brush.Visual = panel;
            rectangle.Fill = brush;

            if (element.Type.Equals("Building"))
                CustomizeBulding(rectangle);
            else if (element.Type.Equals("Street"))
                CustomizeStreet(rectangle);
            else if (element.Type.Equals("Parking"))
                CustomizeParking(rectangle);
            else if (element.Type.Equals("Entrance"))
                CustomizeEntrance(rectangle);
            else
                rectangle.Fill = new SolidColorBrush(Colors.Red);

            Canvas.SetLeft(rectangle, element.X);
            Canvas.SetTop(rectangle, element.Y);

            return rectangle;
        }

        private void CustomizeBulding(Rectangle rectangle)
        {
            rectangle.Stroke = Brushes.CadetBlue;
            rectangle.MouseDown += AdditionalInformationViewModel.openInfo;
        }

        private void CustomizeStreet(Rectangle rectangle)
        {
            rectangle.Fill = new SolidColorBrush(Colors.LightGray);
        }

        private void CustomizeParking(Rectangle rectangle)
        {
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("../../../Images/parking.jpg", UriKind.Relative));
            rectangle.Fill = imageBrush;
        }

        private void CustomizeEntrance(Rectangle rectangle)
        {
            rectangle.Fill = new SolidColorBrush(Colors.RoyalBlue);
        }
    }
}
