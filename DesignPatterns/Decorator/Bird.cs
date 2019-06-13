using System;

namespace DesignPatterns.Decorator
{
    public interface IBird
    {
        int Weight { get; set; }
        void Fly();
    }
    
    public class Bird : IBird
    {
        public int Weight { get; set; }
        
        public void Fly(){
            Console.WriteLine($"Soaring in the sky with weight: {Weight}");
        }
    }
}