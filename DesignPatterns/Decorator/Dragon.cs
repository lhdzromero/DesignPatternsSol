using System;

namespace DesignPatterns.Decorator
{
    public class Dragon : ILizard, IBird
    {
        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();
        private int weight;
        
        public void Crawl(){
            lizard.Crawl();
        }
        
        public void Fly(){
            bird.Fly();
        }
        
       public int Weight 
       { get { return weight; } 
         set 
         {
             weight = value; 
             bird.Weight = value;
             lizard.Weight = value;
         } 
       }
    }
}