using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace DesignPatterns.Singleton
{
    public class OrdinaryDatabase: IDatabase
    {
        public Dictionary<string, int> capitals;
        
        public OrdinaryDatabase(){
            Console.WriteLine("Initializing database ...");
            capitals = File.ReadAllLines(
                Path.Combine(
                    new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName,"./temp/capitals.txt")
            )
            .Batch(2)
            .ToDictionary(
                list => list.ElementAt(0).Trim(),
                list => int.Parse(list.ElementAt(1))
            );    
        }
        
        public int GetPopulation(string name){
            return capitals[name];
        }
        
    }
}