using System.Collections.Generic;

namespace DesignPatterns.Solid {
    public interface IRelationshipBrowser{
        IEnumerable<Person> FindAllChildrenOf(string name);
    }    
}