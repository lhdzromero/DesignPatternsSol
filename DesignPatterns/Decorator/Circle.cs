using System;

namespace DesignPatterns.Decorator
{
    public class Circle : Shape //IShape
    {
        private float radius;
       
        public Circle() : this(0.0f){
            
        }
        
        public Circle(float radius){
            this.radius = radius;
        }
        
        public void Resize(float factor){
            radius *= factor;
        }
        
        //public string AsString() => $"A circle with radius {radius}";
        
        public override string AsString() => $"A circle with radius {radius}";
    }
}