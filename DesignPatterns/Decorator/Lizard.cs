using System;

namespace DesignPatterns.Decorator
{
    public interface ILizard
    {
        int Weight { get; set; }
        void Crawl();
    }
    
    public class Lizard : ILizard
    {
        public int Weight { get; set; }
        
        public void Crawl(){
            Console.WriteLine($"Crawling in the dirt with weight: {Weight}");
        }
    }
}