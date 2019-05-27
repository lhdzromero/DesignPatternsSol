using NUnit.Framework;
using DesignPatterns.Singleton;
using Autofac;

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
        
        [Test]
        public void ConfigurablePopulationTest(){
            var rf = new ConfigurableRecordFinder(new DummyDatabase());
            var names =  new [] {"alpha", "gamma"};
            int tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(4));
        }
        
        [Test]
        public void DIPopulationTest(){
             var names =  new [] {"Manila", "Jakarta"};
            
            var cb = new ContainerBuilder();
            cb.RegisterType<OrdinaryDatabase>()
              .As<IDatabase>()
              .SingleInstance();
              
             cb.RegisterType<ConfigurableRecordFinder>();
             using(var c = cb.Build()){
                 var rf = c.Resolve<ConfigurableRecordFinder>();  
                 Assert.That(rf.GetTotalPopulation(names), Is.GreaterThan(14750000));
             }
        }
        
    }
}
