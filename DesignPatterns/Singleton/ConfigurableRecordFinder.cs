using System;
using System.Collections.Generic;

namespace DesignPatterns.Singleton
{
    public class ConfigurableRecordFinder
    {
        private IDatabase database;
        
        public ConfigurableRecordFinder(IDatabase db){
            this.database = db ?? throw new ArgumentNullException(paramName: nameof(database));
        }
        
        public int GetTotalPopulation(IEnumerable<string> names){
            int result = 0;
            foreach(var name in names)
                result += database.GetPopulation(name);
                
            return result;
        }
        
    }
}