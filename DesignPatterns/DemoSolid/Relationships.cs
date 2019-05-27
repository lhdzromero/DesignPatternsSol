using System.Linq;
using System.Collections.Generic;


namespace DesignPatterns.Solid {
    
    //low-level
    public class Relationships : IRelationshipBrowser{
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();
        
        public void AddParentAndChild(Person parent, Person child){
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }
        
        
        //public List<(Person, Relationship, Person)> Relations => relations;
        
        public IEnumerable<Person> FindAllChildrenOf(string name) {
            foreach(var r in relations.Where(x => x.Item1.Name == "Jhon" && x.Item2 == Relationship.Parent))
                yield return r.Item3;
            
        }
    }
}