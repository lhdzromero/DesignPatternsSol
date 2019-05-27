using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace DesignPatterns.Singleton
{
    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names){
            int result = 0;
            foreach(var name in names)
                result += SingletonDatabase.Instance.GetPopulation(name);
                
            return result;
        }
    }

}