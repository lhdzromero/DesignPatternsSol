using System;

namespace DesignPatterns.Decorator
{
    public class TransparentShape : Shape //IShape
    {
        //private IShape shape;
        private Shape shape;
        private float transparency;
        
        /*
        public TransparentShape(IShape shape, float transparency){
            this.shape = shape ??  throw new ArgumentNullException(paramName: nameof(shape));
            this.transparency = transparency;
        }*/
        
        
        public TransparentShape(Shape shape, float transparency){
            this.shape = shape ??  throw new ArgumentNullException(paramName: nameof(shape));
            this.transparency = transparency;
        }
        
        //public string AsString() => $"{shape.AsString()} has {transparency * 100.0}% transparency";
        
        public override string AsString() => $"{shape.AsString()} has {transparency * 100.0}% transparency";
    
    }
    
    
    public class TransparentShape<T> : Shape where T : Shape, new()    
    {
        private float transparency;
        private T shape = new T();
        
        public TransparentShape() : this(0){
            
        }
        
        public TransparentShape(float transparency){
            this.transparency = transparency;
        }
        
        public override string AsString() => $"{shape.AsString()} has {transparency * 100.0f}% transparency";
    }
    
}