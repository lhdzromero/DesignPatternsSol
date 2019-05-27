using System;
using System.Collections.Generic;

namespace DesignPatterns.Singleton
{
    public class DummyDatabase : IDatabase
    {
        public int GetPopulation(string name){
            return new Dictionary<string, int>
            {
                ["alpha"] = 1,
                ["beta"] = 2,
                ["gamma"] = 3
            }[name];
        }
    }
}