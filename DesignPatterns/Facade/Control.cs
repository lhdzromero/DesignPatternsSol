using System;

namespace DesignPatterns.Facade
{
    public class Control
    {
        protected Subsystem1 subsystem1;
        protected Subsystem2 subsystem2;
       
        public Control(Subsystem1 subsystem1, Subsystem2 subsystem2){
            this.subsystem1 = subsystem1 ?? throw new ArgumentNullException(paramName: nameof(subsystem1));
            this.subsystem2 = subsystem2 ?? throw new ArgumentNullException(paramName: nameof(subsystem2));
        }
        
        public string Operation(){
            string result = "Facade initializes subsystems\n";
            result += this.subsystem1.Operation1();
            result += this.subsystem2.Operation1();
            result += "Facade orders subsystems to perform action:\n";
            result += this.subsystem1.OperationN();
            result += this.subsystem2.OperationN();
                    
            return result;
        }
    }
}