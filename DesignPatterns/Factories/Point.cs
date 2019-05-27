using System;
namespace DesignPatterns.Factories
{
    public class Point
    {
        /*Factory Method
        public static Point NewCartesianPoint(double x, double y){
            return new Point(x, y);
        }
        
        public static Point NewPolarPoint(double rho, double theta){
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }*/
        
        private double X, Y;
        
        internal Point(double x ,double y){
            this.X = x;
            this.Y = y;
        }
        
        public override string ToString(){
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
    
        public static Point Origin = new Point(0,0);
        
        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y){
                return new Point(x, y);
            }
            
            public static Point NewPolarPoint(double rho, double theta){
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }
}