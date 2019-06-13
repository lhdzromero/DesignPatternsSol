using System;

namespace DesignPatterns.Decorator
{
    public class Square : Shape //IShape
    {
        private float side;
        
        
        public Square() : this(0.0f){
            
        }
        
        public Square(float side){
            this.side = side;
        }
        
        //public string AsString() => $"A square with side {side}";
        
        public override string AsString() => $"A square with side {side}";
    }
}