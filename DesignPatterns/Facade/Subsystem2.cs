using System;

namespace DesignPatterns.Facade
{
    public class Subsystem2
    {
        public string Operation1(){
            return "Subsystem2: Get ready!\n";
        }
        
        public string OperationN(){
            return "Subsystem2: Fire!\n";
        }
    }
}