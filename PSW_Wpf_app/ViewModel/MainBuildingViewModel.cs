using PSW_Wpf_app.DrawBuildingElements;
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
        private DrawBuildingEllipse drawBuildingEllipse;
        private DrawBuildingRectangle drawBuildingRectangle;
        public MainBuildingsViewModel(Canvas canvasBuilding)
        {
            List<GraphicElement> elements = new List<GraphicElement>();
            elements = ShapeViewModel.Read();
            drawBuildingEllipse = new DrawBuildingEllipse();
            drawBuildingRectangle = new DrawBuildingRectangle();

            foreach (GraphicElement element in elements)
            {
                if (element.Type.Equals("Fountain") || element.Type.Equals("Circle"))
                {
                    var ellipse = drawBuildingEllipse.DrawEllipse(element);
                    canvasBuilding.Children.Add(ellipse);
                }
                else
                {
                    var rectangle = drawBuildingRectangle.DrawRectangle(element);
                    canvasBuilding.Children.Add(rectangle);
                }
            }

        }
    }
}

