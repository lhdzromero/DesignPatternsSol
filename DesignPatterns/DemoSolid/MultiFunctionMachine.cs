using System;

namespace DesignPatterns.Solid
{
    public class MultiFunctionMachine: IMultiFunctionDevice {
         private IPrinter printer;
         private IScanner scanner;
         
         public MultiFunctionMachine(IPrinter p, IScanner s){
             if (p == null)
                throw new ArgumentNullException(paramName: nameof(p));
                
            if (s == null)
                throw new ArgumentNullException(paramName: nameof(s));
                
            this.printer = p;
            this.scanner = s;
         }
         
         public void Print(Document d){
             printer.Print(d);
         }
         
         public void Scan(Document d){
             scanner.Scan(d);
         }
    }
}