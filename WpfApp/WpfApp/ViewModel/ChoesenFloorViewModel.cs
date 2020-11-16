using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfApp.Model;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace WpfApp.ViewModel
{
    public class ChoesenFloorViewModel : BindableBase
    {

        #region Infrastructure
        private BindableBase _currentContentViewModel;
        public BindableBase CurrentContentViewModel
        {
            get { return _currentContentViewModel; }
            set { SetField(ref _currentContentViewModel, value); }
        }
        #endregion

        #region ViewModels
        private ChoesenFloorViewModel choesenFloorViewModel;
        #endregion


        public delegate void ApplyPriorityEventHandler(object source, EventArgs args);
        public event ApplyPriorityEventHandler ApplyingPriority;

        private string choosenBuilding;
        public string ChoosenBuilding
        {
            get { return choosenBuilding; }
            set
            {
                SetField(ref choosenBuilding, value);
            }
        }

        private int choosenFloor;
        public int ChoosenFloor
        {
            get { return choosenFloor; }
            set
            {
                SetField(ref choosenFloor, value);
            }
        }


        public ChoesenFloorViewModel(Canvas Can2, string buil, int floor)
        {

            choosenBuilding = buil;
            choosenFloor = floor;

            List<FloorElement> floors = new List<FloorElement>();
            List<FloorElement> floorsM = new List<FloorElement>();
            List<FloorElement> floorsP = new List<FloorElement>();
            floors = ShapeViewModel.ReadFloor();
            floorsM = ShapeViewModel.ReadFloorMedical();
            floorsP = ShapeViewModel.ReadFloorPediatric();


            switch (ChoosenBuilding)
            {
                case "Surgical":

                    foreach (FloorElement f in floors)
                    {
                        if (f.Floor.Equals(choosenFloor))
                        {

                            if (f.Type.Equals("room"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);
                                rectangle.Name = f.Name;
                                rectangle.MouseDown += openInfo;


                                VisualBrush vbc = new VisualBrush();
                                StackPanel aPanel = new StackPanel();
                                aPanel.Background = new SolidColorBrush(Colors.CadetBlue);

                                // Create some text.
                                TextBlock someText = new TextBlock();
                                someText.Text = f.Name;
                                someText.FontSize = 5;
                                someText.Margin = new Thickness(8);
                                someText.TextWrapping = TextWrapping.Wrap;

                                aPanel.Children.Add(someText);
                                // aPanel.Children.Add(button);
                                vbc.Visual = aPanel;
                                rectangle.Fill = vbc;

                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);
                            }
                            else if (f.Type.Equals("counter"))
                            {
                                Ellipse ellipse = new Ellipse();
                                ellipse.Width = f.Width;
                                ellipse.Height = f.Height;
                                //ellipse.Fill = new SolidColorBrush(Colors.Black);
                                ellipse.Name = f.Type;
                                ellipse.Stroke = new SolidColorBrush(Colors.Black);

                                ImageBrush myBrush = new ImageBrush();


                                myBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\Maja\Desktop\psw\WellDevClinic\WpfApp\Images\info.png"));



                                ellipse.Fill = myBrush;

                                Canvas.SetLeft(ellipse, f.X);
                                Canvas.SetTop(ellipse, f.Y);


                                Can2.Children.Add(ellipse);
                            }
                            else if (f.Type.Equals("restroom"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                rectangle.Fill = new SolidColorBrush(Colors.DarkSeaGreen);
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);

                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);
                            }
                            else if (f.Type.Equals("elevator"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                rectangle.Fill = new SolidColorBrush(Colors.LightGray);
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);

                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);
                            }
                            else if (f.Type.Equals("stairs"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                rectangle.Fill = new SolidColorBrush(Colors.Gray);
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);

                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);
                            }
                            else if (f.Type.Equals("door"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                rectangle.Fill = new SolidColorBrush(Colors.Black);
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);

                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);
                            }
                            else if (f.Type.Equals("waitingRoom"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);

                                ImageBrush myBrush = new ImageBrush();

                                myBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\Maja\Desktop\psw\WellDevClinic\WpfApp\Images\waiting-room.png"));
                                rectangle.Fill = myBrush;

                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);
                            }
                            else if (f.Type.Equals("base"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                rectangle.Fill = new SolidColorBrush(Colors.Transparent);
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);

                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);
                            }


                        }
                    }


                    ApplyingPriority?.Invoke(this, null);
                    break;

                case "MedicalCenter":

                    foreach (FloorElement f in floorsM)
                    {
                        if (f.Floor.Equals(choosenFloor))
                        {
                            if (f.Type.Equals("roomP"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                //rectangle.Fill = new SolidColorBrush(Colors.CadetBlue);
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);
                                rectangle.Name = f.Name;
                                rectangle.MouseDown += openInfo;

                                VisualBrush vbc = new VisualBrush();
                                StackPanel aPanel = new StackPanel();
                                aPanel.Background = new SolidColorBrush(Colors.CadetBlue);

                                // Create some text.
                                TextBlock someText = new TextBlock();
                                someText.Text = f.Name;
                                someText.FontSize = 5;
                                someText.Margin = new Thickness(8);
                                someText.TextWrapping = TextWrapping.Wrap;

                                aPanel.Children.Add(someText);
                                // aPanel.Children.Add(button);
                                vbc.Visual = aPanel;
                                rectangle.Fill = vbc;

                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);

                            }
                            else if (f.Type.Equals("roomE"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                //rectangle.Fill = new SolidColorBrush(Colors.CadetBlue);
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);
                                rectangle.Name = f.Name;
                                rectangle.MouseDown += openInfo;

                                VisualBrush vbc = new VisualBrush();
                                StackPanel aPanel = new StackPanel();
                                aPanel.Background = new SolidColorBrush(Colors.LightSeaGreen);

                                // Create some text.
                                TextBlock someText = new TextBlock();
                                someText.Text = f.Name;
                                someText.FontSize = 5;
                                someText.Margin = new Thickness(8);
                                someText.TextWrapping = TextWrapping.Wrap;

                                aPanel.Children.Add(someText);
                                // aPanel.Children.Add(button);
                                vbc.Visual = aPanel;
                                rectangle.Fill = vbc;

                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);

                            }
                            else if (f.Type.Equals("counter"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                //rectangle.Fill = new SolidColorBrush(Colors.CadetBlue);
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);

                                VisualBrush vbc = new VisualBrush();
                                StackPanel aPanel = new StackPanel();
                                aPanel.Background = new SolidColorBrush(Colors.CadetBlue);

                                // Create some text.
                                TextBlock someText = new TextBlock();
                                someText.Text = f.Name;
                                someText.FontSize = 5;
                                someText.Margin = new Thickness(8);
                                someText.TextWrapping = TextWrapping.Wrap;

                                aPanel.Children.Add(someText);
                                // aPanel.Children.Add(button);
                                vbc.Visual = aPanel;
                                rectangle.Fill = vbc;

                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);
                            }
                            else if (f.Type.Equals("restroom"))
                            {

                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                //rectangle.Fill = new SolidColorBrush(Colors.CadetBlue);
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);

                                VisualBrush vbc = new VisualBrush();
                                StackPanel aPanel = new StackPanel();
                                aPanel.Background = new SolidColorBrush(Colors.DarkSeaGreen);

                                // Create some text.
                                TextBlock someText = new TextBlock();
                                someText.Text = f.Name;
                                someText.FontSize = 5;
                                someText.Margin = new Thickness(8);
                                someText.TextWrapping = TextWrapping.Wrap;

                                aPanel.Children.Add(someText);
                                // aPanel.Children.Add(button);
                                vbc.Visual = aPanel;
                                rectangle.Fill = vbc;

                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);
                            }
                            else if (f.Type.Equals("elevator"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                //rectangle.Fill = new SolidColorBrush(Colors.CadetBlue);
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);

                                VisualBrush vbc = new VisualBrush();
                                StackPanel aPanel = new StackPanel();
                                aPanel.Background = new SolidColorBrush(Colors.LightGray);

                                // Create some text.
                                TextBlock someText = new TextBlock();
                                someText.Text = f.Name;
                                someText.FontSize = 5;
                                someText.Margin = new Thickness(8);
                                someText.TextWrapping = TextWrapping.Wrap;

                                aPanel.Children.Add(someText);
                                // aPanel.Children.Add(button);
                                vbc.Visual = aPanel;
                                rectangle.Fill = vbc;

                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);
                            }
                            else if (f.Type.Equals("stairs"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                //rectangle.Fill = new SolidColorBrush(Colors.CadetBlue);
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);

                                VisualBrush vbc = new VisualBrush();
                                StackPanel aPanel = new StackPanel();
                                aPanel.Background = new SolidColorBrush(Colors.Gray);

                                // Create some text.
                                TextBlock someText = new TextBlock();
                                someText.Text = f.Name;
                                someText.FontSize = 5;
                                someText.Margin = new Thickness(8);
                                someText.TextWrapping = TextWrapping.Wrap;

                                aPanel.Children.Add(someText);
                                // aPanel.Children.Add(button);
                                vbc.Visual = aPanel;
                                rectangle.Fill = vbc;

                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);
                            }
                            else if (f.Type.Equals("door"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                rectangle.Fill = new SolidColorBrush(Colors.Black);
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);

                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);
                            }
                            else if (f.Type.Equals("waitingRoom"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                rectangle.Fill = new SolidColorBrush(Colors.Yellow);
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);

                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);
                            }
                            else if (f.Type.Equals("base"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                rectangle.Fill = new SolidColorBrush(Colors.Transparent);
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);

                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);
                            }

                        }
                    }

                    break;

                case "Pediatrics":
                    foreach (FloorElement f in floorsP)
                    {
                        if (f.Floor.Equals(choosenFloor))
                        {

                            if (f.Type.Equals("room"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);
                                rectangle.Name = f.Name;
                                rectangle.MouseDown += openInfo;

                                VisualBrush vbc = new VisualBrush();
                                StackPanel aPanel = new StackPanel();
                                aPanel.Background = new SolidColorBrush(Colors.CadetBlue);

                                // Create some text.
                                TextBlock someText = new TextBlock();
                                someText.Text = f.Name;
                                someText.FontSize = 5;
                                someText.Margin = new Thickness(8);
                                someText.TextWrapping = TextWrapping.Wrap;

                                aPanel.Children.Add(someText);
                                // aPanel.Children.Add(button);
                                vbc.Visual = aPanel;
                                rectangle.Fill = vbc;


                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);
                            }
                            else if (f.Type.Equals("elipsa"))
                            {
                                Ellipse ellipse = new Ellipse();
                                ellipse.Width = f.Width;
                                ellipse.Height = f.Height;
                                ellipse.Fill = new SolidColorBrush(Colors.Yellow);
                                ellipse.Name = f.Type;

                                Canvas.SetLeft(ellipse, f.X);
                                Canvas.SetTop(ellipse, f.Y);


                                Can2.Children.Add(ellipse);
                            }
                            else if (f.Type.Equals("counter"))
                            {
                                Ellipse ellipse = new Ellipse();
                                ellipse.Width = f.Width;
                                ellipse.Height = f.Height;
                                ellipse.Fill = new SolidColorBrush(Colors.Yellow);
                                ellipse.Name = f.Type;

                                Canvas.SetLeft(ellipse, f.X);
                                Canvas.SetTop(ellipse, f.Y);


                                Can2.Children.Add(ellipse);
                            }
                            else if (f.Type.Equals("stuf"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                rectangle.Fill = new SolidColorBrush(Colors.Orange);
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);

                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);
                            }
                            else if (f.Type.Equals("toilet"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);

                                VisualBrush vbc = new VisualBrush();
                                StackPanel aPanel = new StackPanel();
                                aPanel.Background = new SolidColorBrush(Colors.DarkSeaGreen);

                                // Create some text.
                                TextBlock someText = new TextBlock();
                                someText.Text = f.Name;
                                someText.FontSize = 5;
                                someText.Margin = new Thickness(8);
                                someText.TextWrapping = TextWrapping.Wrap;

                                aPanel.Children.Add(someText);
                                // aPanel.Children.Add(button);
                                vbc.Visual = aPanel;
                                rectangle.Fill = vbc;


                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);
                            }

                            else if (f.Type.Equals("entrance"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                rectangle.Fill = new SolidColorBrush(Colors.LightGray);
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);

                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);
                            }
                            else if (f.Type.Equals("base"))
                            {
                                Rectangle rectangle = new Rectangle();
                                rectangle.Width = f.Width;
                                rectangle.Height = f.Height;
                                rectangle.Fill = new SolidColorBrush(Colors.Transparent);
                                rectangle.Stroke = new SolidColorBrush(Colors.Black);

                                Canvas.SetLeft(rectangle, f.X);
                                Canvas.SetTop(rectangle, f.Y);

                                Can2.Children.Add(rectangle);
                            }


                        }
                    }
                    break;

            }
            void openInfo(object sender, MouseButtonEventArgs e)
            {
                var mouseWasDownOn = e.Source as FrameworkElement;
                if (mouseWasDownOn != null)
                {
                    string elementName = mouseWasDownOn.Name;
                    Console.WriteLine(elementName);
                    foreach (FloorElement f in floors)
                    {
                        if (elementName.Equals(f.Name))
                        {
                            string info = f.Info;
                            Console.WriteLine(info);
                            MessageBox.Show(string.Format("additional information: {0}\n", info));
                        }
                    }
                    foreach (FloorElement f in floorsP)
                    {
                        if (elementName.Equals(f.Name))
                        {
                            string info = f.Info;
                            Console.WriteLine(info);
                            MessageBox.Show(string.Format("additional information {0}\n", info));
                        }
                    }
                    foreach (FloorElement f in floorsM)
                    {
                        if (elementName.Equals(f.Name))
                        {
                            string info = f.Info;
                            Console.WriteLine(info);
                            MessageBox.Show(string.Format("additional information {0}\n", info));
                        }
                    }

                }
            }

        }
    }
}
