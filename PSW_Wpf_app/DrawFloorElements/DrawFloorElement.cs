using System;
using System.Collections.Generic;
using System.Windows.Controls;
using PSW_Wpf_app.Model;
using System.Windows.Shapes;

namespace PSW_Wpf_app.Drawing
{
    public class DrawFloorElement
    {
        private Dictionary<string, string> mapElementsToShape;
        private Canvas canvasFloor;
        public DrawFloorElement(Canvas canvasFloor)
        {
            this.canvasFloor = canvasFloor;
            mapElementsToShape = new Dictionary<string, string>();
            mapElementsToShape.Add("room", "Rectangle");
            mapElementsToShape.Add("counter", "Elipse");
            mapElementsToShape.Add("restroom", "Rectangle");
            mapElementsToShape.Add("storageRoom", "Rectangle");
            mapElementsToShape.Add("elevator", "Rectangle");
            mapElementsToShape.Add("stairs", "Rectangle");
            mapElementsToShape.Add("door", "Rectangle");
            mapElementsToShape.Add("waitingRoom", "Rectangle");
            mapElementsToShape.Add("base", "Rectangle");
            mapElementsToShape.Add("elipsa", "Elipse");
        }
        public Shape DrawElement(FloorElement floorElement, bool flag=false)
        {
            string shapeType;
            if (!mapElementsToShape.TryGetValue(floorElement.Type, out shapeType))
            {
                throw new Exception($"Floor element of type '{floorElement.Type}' not recognized.");
            }

            if (shapeType.Equals("Rectangle"))
            {
                DrawRectangleElementFloor drawRectangleElement = new DrawRectangleElementFloor(floorElement);
                return drawRectangleElement.DrawRectangleElement(flag);
            }
            else
            {
                DrawEllipseElementFloor drawEllipseElement = new DrawEllipseElementFloor(floorElement);
                return drawEllipseElement.DrawEllipseElement(flag);
            }
        }

    }
}
