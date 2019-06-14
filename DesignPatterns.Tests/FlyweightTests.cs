using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using DesignPatterns.Flyweight;
using JetBrains.dotMemoryUnit;

namespace Tests
{
    [TestFixture]
    public class FlyweightTests
    { 
        [Test]
        public void TestUser(){
            var firstNames = Enumerable.Range(0,100).Select(_ => RandomString());
            var lastNames  = Enumerable.Range(0,100).Select(_ => RandomString());
            
            var users = new List<User>();
            
            foreach(var firstName in firstNames)
                foreach(var lastName in lastNames)
                    users.Add(new User($"{firstName} {lastName}"));
                        
            ForceGC();
            
            dotMemory.Check(memory =>
            {
               Console.WriteLine(memory.SizeInBytes);
            });
        }
        
        [Test]
        public void TestUser2(){
            var firstNames = Enumerable.Range(0,100).Select(_ => RandomString());
            var lastNames  = Enumerable.Range(0,100).Select(_ => RandomString());
            
            var users = new List<User>();
            
            foreach(var firstName in firstNames)
                foreach(var lastName in lastNames)
                    users.Add(new User2($"{firstName} {lastName}"));
                        
            ForceGC();
            
            dotMemory.Check(memory =>
            {
               Console.WriteLine(memory.SizeInBytes);
            });
        }
        
        private void ForceGC(){
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        
        private string RandomString(){
            Random rand = new Random();
            return new string(
                Enumerable.Range(0,10)
                .Select(i => (char)('a' + rand.Next(26)))
                .ToArray());
        }
    }
}
