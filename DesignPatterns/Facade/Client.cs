using System;

namespace DesignPatterns.Facade
{
    public class Client
    {
        public static void ClientCall(Control control){
            Console.Write(control.Operation());
        }
    }
}