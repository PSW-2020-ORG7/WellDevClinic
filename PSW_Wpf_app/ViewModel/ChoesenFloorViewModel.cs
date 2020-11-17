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

        List<FloorElement> floors = new List<FloorElement>();

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

        public ChoesenFloorViewModel(Canvas canvasFloor, string buil, int floor)
        {
            choosenBuilding = buil;
            choosenFloor = floor;

            floors = getFloor(ChoosenBuilding);


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

                        VisualBrush brush = new VisualBrush();
                        StackPanel panel = new StackPanel();
                        panel.Background = new SolidColorBrush(Colors.CadetBlue);

                        TextBlock roomName = new TextBlock();
                        roomName.Text = f.Name;
                        roomName.FontSize = 5;
                        roomName.Margin = new Thickness(8);

                        panel.Children.Add(roomName);
                        brush.Visual = panel;
                        rectangle.Fill = brush;

                        Canvas.SetLeft(rectangle, f.X);
                        Canvas.SetTop(rectangle, f.Y);

                        canvasFloor.Children.Add(rectangle);
                    }
                    else if (f.Type.Equals("counter"))
                    {
                        Ellipse ellipse = new Ellipse();
                        ellipse.Width = f.Width;
                        ellipse.Height = f.Height;
                        ellipse.Name = f.Type;
                        ellipse.Stroke = new SolidColorBrush(Colors.Black);

                        ImageBrush myBrush = new ImageBrush();
                        myBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\Lenovo\Desktop\psw\WellDevClinic\WpfApp\Images\info.png"));

                        ellipse.Fill = myBrush;

                        Canvas.SetLeft(ellipse, f.X);
                        Canvas.SetTop(ellipse, f.Y);

                        canvasFloor.Children.Add(ellipse);
                    }
                    else if (f.Type.Equals("restroom"))
                    {
                        Rectangle rectangle = new Rectangle();
                        rectangle.Width = f.Width;
                        rectangle.Height = f.Height;
                        rectangle.Stroke = new SolidColorBrush(Colors.Black);

                        VisualBrush brush = new VisualBrush();
                        StackPanel panel = new StackPanel();
                        panel.Background = new SolidColorBrush(Colors.LightSteelBlue);

                        TextBlock roomName = new TextBlock();
                        roomName.Text = f.Name;
                        roomName.FontSize = 5;
                        roomName.Margin = new Thickness(8);

                        panel.Children.Add(roomName);
                        brush.Visual = panel;
                        rectangle.Fill = brush;

                        Canvas.SetLeft(rectangle, f.X);
                        Canvas.SetTop(rectangle, f.Y);

                        canvasFloor.Children.Add(rectangle);
                    }
                    else if (f.Type.Equals("storageRoom"))
                    {
                        Rectangle rectangle = new Rectangle();
                        rectangle.Width = f.Width;
                        rectangle.Height = f.Height;
                        rectangle.Stroke = new SolidColorBrush(Colors.Black);

                        VisualBrush brush = new VisualBrush();
                        StackPanel panel = new StackPanel();
                        panel.Background = new SolidColorBrush(Colors.Tan);

                        TextBlock roomName = new TextBlock();
                        roomName.Text = f.Name;
                        roomName.FontSize = 5;
                        roomName.Margin = new Thickness(8);

                        panel.Children.Add(roomName);
                        brush.Visual = panel;
                        rectangle.Fill = brush;

                        Canvas.SetLeft(rectangle, f.X);
                        Canvas.SetTop(rectangle, f.Y);

                        canvasFloor.Children.Add(rectangle);
                    }
                    else if (f.Type.Equals("elevator"))
                    {
                        Rectangle rectangle = new Rectangle();
                        rectangle.Width = f.Width;
                        rectangle.Height = f.Height;
                        rectangle.Stroke = new SolidColorBrush(Colors.Black);

                        VisualBrush brush = new VisualBrush();
                        StackPanel panel = new StackPanel();
                        panel.Background = new SolidColorBrush(Colors.LightGray);

                        TextBlock roomName = new TextBlock();
                        roomName.Text = f.Name;
                        roomName.FontSize = 5;
                        roomName.Margin = new Thickness(8);

                        panel.Children.Add(roomName);
                        brush.Visual = panel;
                        rectangle.Fill = brush;

                        Canvas.SetLeft(rectangle, f.X);
                        Canvas.SetTop(rectangle, f.Y);

                        canvasFloor.Children.Add(rectangle);
                    }
                    else if (f.Type.Equals("stairs"))
                    {
                        Rectangle rectangle = new Rectangle();
                        rectangle.Width = f.Width;
                        rectangle.Height = f.Height;
                        rectangle.Stroke = new SolidColorBrush(Colors.Black);

                        VisualBrush brush = new VisualBrush();
                        StackPanel panel = new StackPanel();
                        panel.Background = new SolidColorBrush(Colors.Gray);

                        TextBlock roomName = new TextBlock();
                        roomName.Text = f.Name;
                        roomName.FontSize = 5;
                        roomName.Margin = new Thickness(8);

                        panel.Children.Add(roomName);
                        brush.Visual = panel;
                        rectangle.Fill = brush;

                        Canvas.SetLeft(rectangle, f.X);
                        Canvas.SetTop(rectangle, f.Y);

                        canvasFloor.Children.Add(rectangle);
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

                        canvasFloor.Children.Add(rectangle);
                    }
                    else if (f.Type.Equals("waitingRoom"))
                    {
                        Rectangle rectangle = new Rectangle();
                        rectangle.Width = f.Width;
                        rectangle.Height = f.Height;
                        rectangle.Stroke = new SolidColorBrush(Colors.Black);

                        ImageBrush myBrush = new ImageBrush();

                        myBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\Lenovo\Desktop\psw\WellDevClinic\WpfApp\Images\waiting-room.png"));
                        rectangle.Fill = myBrush;

                        Canvas.SetLeft(rectangle, f.X);
                        Canvas.SetTop(rectangle, f.Y);

                        canvasFloor.Children.Add(rectangle);
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

                        canvasFloor.Children.Add(rectangle);
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

                        canvasFloor.Children.Add(ellipse);
                    }
                }
            }

        }


        private List<FloorElement> getFloor(object name)
        {
            string pathSurgical = @"~\..\..\..\surgicalBranchesFloors.txt";
            string pathMedical = @"~\..\..\..\medicalCenter.txt";
            string pathPediatrics = @"~\..\..\..\pediatrics.txt";

            List<FloorElement> floors = new List<FloorElement>();

            switch (ChoosenBuilding)
            {
                case "Surgical":
                    floors = ShapeViewModel.ReadFloor(pathSurgical);
                    break;
                case "MedicalCenter":
                    floors = ShapeViewModel.ReadFloor(pathMedical);
                    break;
                case "Pediatrics":
                    floors = ShapeViewModel.ReadFloor(pathPediatrics);
                    break;
            }

            return floors;
        }
        void openInfo(object sender, MouseButtonEventArgs e)
        {
            floors = getFloor(ChoosenBuilding);

            var mouseWasDownOn = e.Source as FrameworkElement;
            if (mouseWasDownOn != null)
            {
                string elementName = mouseWasDownOn.Name;
                foreach (FloorElement f in floors)
                {
                    if (elementName.Equals(f.Name))
                        MessageBox.Show(string.Format("additional information: {0}\n", f.Info));
                }
            }
        }

    }
}
