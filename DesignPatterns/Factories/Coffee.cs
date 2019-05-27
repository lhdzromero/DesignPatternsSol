using System;
namespace DesignPatterns.Factories
{
    public class Coffee: IHotDrink
    {
        public void Consume(){
            Console.WriteLine("This coffee is sensational!");
        }
    }
}