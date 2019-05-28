using System;
using System.Collections.Generic;

namespace  DesignPatterns.Adapter
{
    public class VectorRectangule : VectorObject
    {
        public VectorRectangule(int x, int y, int width, int height){
            Add(new Line(new Point(x, y), new Point(x + width, y)));
            Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
            Add(new Line(new Point(x, y), new Point(x, y + height)));
            Add(new Line(new Point(x, y + height), new Point(x + width, y + height)));
        }
    }
}