using System;

namespace DesignPatterns.Decorator
{
    public class ColoredShape : Shape //IShape
    {
        //private IShape shape;
        private Shape shape;
        private string color;
        
        /*
        public ColoredShape(IShape shape, string color){
            this.shape = shape ?? throw new ArgumentNullException(paramName: nameof(shape));
            this.color = color ?? throw new ArgumentNullException(paramName: nameof(color));
        }*/
        
        public ColoredShape(Shape shape, string color){
            this.shape = shape ?? throw new ArgumentNullException(paramName: nameof(shape));
            this.color = color ?? throw new ArgumentNullException(paramName: nameof(color));
        }
        
        
        //public string AsString() => $"{shape.AsString()} has the color {color}";
        
        public override string AsString() => $"{shape.AsString()} has the color {color}";
    }
    
    public class ColoredShape<T> : Shape where T : Shape, new()    
    {
        private string color;
        private T shape = new T();
        
        public ColoredShape() : this("black"){
            
        }
        
        public ColoredShape(string color){
            this.color = color ?? throw new ArgumentNullException(paramName: nameof(color));
        }
        
        public override string AsString() => $"{shape.AsString()} has the color {color}";
    }
    
}
