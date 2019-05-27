using NUnit.Framework;
using DesignPatterns.Singleton;

namespace Tests
{
    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void IsSingletonTest(){
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;
            Assert.That(db, Is.SameAs(db2));
            Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
        }
        
        [Test]
        public void SingletonTotalPopulationTest(){
            var rf = new SingletonRecordFinder();
            var names = new [] {"Seoul","Mexico City"};
            int tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(17500000 + 17400000));
        }
    }
}
