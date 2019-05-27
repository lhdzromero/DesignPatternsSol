using System;

namespace DesignPatterns.Solid
{
    //La inerfaz de proposito general NO ES viable para otros objentos que no requieren todas sus funcionalidades 
    public class OldFashionedPrintter: IMachine {

        public void Print(Document d){
            //Funcionalidad necesaria
        }

        public void Scan(Document d){
          //Funcionalidad Inneceasaria que nos obliga a implementar la interfaz de proposito general  
          throw new NotImplementedException();
        }
        
        public void Fax(Document d){
          //Funcionalidad Inneceasaria que nos obliga a implementar la interfaz de proposito general
          throw new NotImplementedException();
        }
        
    }
}