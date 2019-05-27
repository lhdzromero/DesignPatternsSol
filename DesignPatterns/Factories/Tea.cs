using System;

namespace DesignPatterns.Factories
{
    public class Tea: IHotDrink
    {
        public void Consume(){
            Console.WriteLine("This Tea is nice but I'd prefer it with milk.");
        }
    }
}