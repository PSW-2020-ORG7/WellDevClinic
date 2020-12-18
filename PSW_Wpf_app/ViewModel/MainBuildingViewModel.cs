using PSW_Wpf_app.DrawBuildingElements;
using System.Collections.Generic;
using System.Windows.Controls;
using PSW_Wpf_app.Model;

namespace PSW_Wpf_app.ViewModel
{
    class MainBuildingsViewModel : BindableBase
    {
        private DrawBuildingEllipse drawBuildingEllipse;
        private DrawBuildingRectangle drawBuildingRectangle;
        private List<GraphicElement> elements = new List<GraphicElement>();
        public MainBuildingsViewModel(Canvas canvasBuilding)
        {
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

