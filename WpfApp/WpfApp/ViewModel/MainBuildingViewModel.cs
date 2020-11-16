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
        public MainBuildingsViewModel(Canvas Can1)
        {
            List<GraphicElement> elements = new List<GraphicElement>();
            elements = ShapeViewModel.Read();


            foreach (GraphicElement element in elements)
            {
                if (element.Type.Equals("Fontana"))
                {
                    Ellipse ellipse = new Ellipse();
                    ellipse.Width = element.Width;
                    ellipse.Height = element.Height;
                    ellipse.Fill = new SolidColorBrush(Colors.LightGray);

                    Canvas.SetLeft(ellipse, element.X);
                    Canvas.SetTop(ellipse, element.Y);

                    Can1.Children.Add(ellipse);
                }
                else if (element.Type.Equals("Krug"))
                {
                    Ellipse ellipse = new Ellipse();
                    ellipse.Width = element.Width;
                    ellipse.Height = element.Height;
                    ellipse.Fill = new SolidColorBrush(Colors.SteelBlue);
                    ellipse.Name = element.Type;

                    Canvas.SetLeft(ellipse, element.X);
                    Canvas.SetTop(ellipse, element.Y);


                    Can1.Children.Add(ellipse);
                }
                else
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Name = element.Name;
                    rectangle.Width = element.Width;
                    rectangle.Height = element.Height;

                    VisualBrush vbc = new VisualBrush();
                    // Create the brush's contents.
                    //
                    StackPanel aPanel = new StackPanel();
                    aPanel.Background = new SolidColorBrush(Colors.CadetBlue);

                    // Create some text.
                    TextBlock someText = new TextBlock();
                    someText.Text = element.Name;
                    someText.FontSize = 7;
                    someText.Margin = new Thickness(8);
                    someText.TextWrapping = TextWrapping.Wrap;

                    aPanel.Children.Add(someText);
                    // aPanel.Children.Add(button);
                    vbc.Visual = aPanel;
                    rectangle.Fill = vbc;
                    if (element.Type.Equals("Zgrada"))
                    {
                        // rectangle.Fill = new SolidColorBrush(Colors.CadetBlue);
                        rectangle.Stroke = Brushes.CadetBlue;
                        rectangle.MouseDown += openInfo;
                    }
                    else if (element.Type.Equals("Ulica"))
                        rectangle.Fill = new SolidColorBrush(Colors.LightGray);
                    else if (element.Type.Equals("Parking"))
                    {

                        ImageBrush myBrush = new ImageBrush();

                        myBrush.ImageSource =

                            new BitmapImage(new Uri(@"C:\Users\Maja\Desktop\psw\WellDevClinic\WpfApp\Images\parking.jpg"));

                        rectangle.Fill = myBrush;
                    }
                    else if (element.Type.Equals("Ulaz"))
                        rectangle.Fill = new SolidColorBrush(Colors.RoyalBlue);
                    else
                        rectangle.Fill = new SolidColorBrush(Colors.Red);

                    Canvas.SetLeft(rectangle, element.X);
                    Canvas.SetTop(rectangle, element.Y);


                    Can1.Children.Add(rectangle);

                }
            }

        }
        void openInfo(object sender, MouseButtonEventArgs e)
        {
            var mouseWasDownOn = e.Source as FrameworkElement;
            if (mouseWasDownOn != null)
            {
                string elementName = mouseWasDownOn.Name;
                Console.WriteLine(elementName);
                if (elementName.Equals("Surgical"))
                {
                    MessageBox.Show("SURGICAL - MORE INFORMATION\n\n" +
                           "This building has a ground floor and a first floor.\n" +
                           "In the ground floor there are ambulance and ER.Patience can come here when they have an unexcepted injury or fractue. " +
                           "We have an excellent X-ray and many other medical devices in our diagnostic office.\n" +
                           "On the ground floor there are also info desk and waiting room. \n" +
                           "On the first floor there are operating rooms and recovering rooms.\n" +
                           "We also have elevators for every entrance which patients can use.\n" +
                           "info pult -> contact +0044/014789889\n" +


                           "");
                }
                else if (elementName.Equals("MedicalCenter"))
                {
                    MessageBox.Show("MEDICAL CENTER - MORE INFORMATION\n\n" +
                    "This building has a ground floor and 3 more floors.\n" +
                      "On the ground floor there are info desk, cardiologist, dermatology, ORL,orthopedic,urology,physiatry and endocrinology. " +
                      "On the first floor there are stomatology, gynecology and physiatry. \n" +
                      "On the second floor there are general practise, cardiologist, dermatology and ORL . \n" +
                      "On the third floor there are immunologist, infectology and radiology.\n" +
                      "info pult -> contact +0044/014678777\n" +

                    "");
                }
                else if (elementName.Equals("Pediatrics"))
                {

                    MessageBox.Show("PEDIATRICS - MORE INFORMATION\n\n" +
                      "This building has a ground floor and a first floor.\n" +
                      "On the ground floor there are examination rooms, laboratory,feeding area for babys and stuff room. " +
                      "On the first floor there are pediatrics day care,play area for childreen, pediatric rehabilitation and pediatric neurology \n" +
                      "Also there is cantine for lunch and information pult. \n" +
                      "We also have elevators for every entrance which patients can use.\n" +
                      "info pult -> contact +0044/014678543\n" +


                        "");
                }

            }

        }
    }
}
