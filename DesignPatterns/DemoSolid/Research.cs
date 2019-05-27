using System;
using System.Linq;

namespace DesignPatterns.Solid {
    
    public class Research {
        /*
        public Research(Relationships relationships){
            
            var relations = relationships.Relations;
            
            foreach(var r in relations.Where(x => x.Item1.Name == "Jhon" && x.Item2 == Relationship.Parent)){
                Console.WriteLine($"Jhon has a child called  {r.Item3.Name}");
            }
        } 
        */
       
       public Research(IRelationshipBrowser browser){
           foreach(var p  in browser.FindAllChildrenOf("Jhon"))
                Console.WriteLine($"Jhon has a child called  {p.Name}");
       }
    }
    
}