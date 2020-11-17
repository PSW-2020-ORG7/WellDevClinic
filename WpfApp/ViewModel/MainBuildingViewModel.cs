using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    class MainBuildingsViewModel : BindableBase
    {
        public MainBuildingsViewModel(Canvas canvasBuilding)
        {
            List<GraphicElement> elements = new List<GraphicElement>();
            elements = ShapeViewModel.Read();


            foreach (GraphicElement element in elements)
            {
                if (element.Type.Equals("Fountain"))
                {
                    Ellipse ellipse = new Ellipse();
                    ellipse.Width = element.Width;
                    ellipse.Height = element.Height;
                    ellipse.Fill = new SolidColorBrush(Colors.LightGray);

                    Canvas.SetLeft(ellipse, element.X);
                    Canvas.SetTop(ellipse, element.Y);

                    canvasBuilding.Children.Add(ellipse);
                }
                else if (element.Type.Equals("Circle"))
                {
                    Ellipse ellipse = new Ellipse();
                    ellipse.Width = element.Width;
                    ellipse.Height = element.Height;
                    ellipse.Fill = new SolidColorBrush(Colors.SteelBlue);
                    ellipse.Name = element.Type;

                    Canvas.SetLeft(ellipse, element.X);
                    Canvas.SetTop(ellipse, element.Y);

                    canvasBuilding.Children.Add(ellipse);
                }
                else
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
                    {
                        rectangle.Stroke = Brushes.CadetBlue;
                        rectangle.MouseDown += AdditionalInformationViewModel.openInfo;
                    }
                    else if (element.Type.Equals("Street"))
                        rectangle.Fill = new SolidColorBrush(Colors.LightGray);
                    else if (element.Type.Equals("Parking"))
                    {

                        ImageBrush imageBrush = new ImageBrush();

                        imageBrush.ImageSource =

                            new BitmapImage(new Uri(@"C:\Users\Lenovo\Desktop\psw\WellDevClinic\WpfApp\Images\parking.jpg"));

                        rectangle.Fill = imageBrush;
                    }
                    else if (element.Type.Equals("Entrance"))
                        rectangle.Fill = new SolidColorBrush(Colors.RoyalBlue);
                    else
                        rectangle.Fill = new SolidColorBrush(Colors.Red);

                    Canvas.SetLeft(rectangle, element.X);
                    Canvas.SetTop(rectangle, element.Y);
                    canvasBuilding.Children.Add(rectangle);
                    

                }
            }

        }
        
        }
    }

