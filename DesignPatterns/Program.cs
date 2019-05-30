using System;
using System.Diagnostics;
using System.Collections.Generic;
using MoreLinq;
using System.Text;
using Autofac;
using static System.Console;

namespace DesignPatterns
{
    class Program
    {
        static public int Area(Solid.Rectangule r) => r.Width * r.Height;
        
        private static readonly List<Adapter.VectorObject> vectorObjects 
            = new List<Adapter.VectorObject>
            {
                new Adapter.VectorRectangule(1,1,10,10),
                new Adapter.VectorRectangule(3,3,6,6)
            };
        
        static void Main(string[] args)
        {
            Console.WriteLine("Course Designs Patterns");
            
            var option = Demo.Composite;
            
            switch(option){
                case Demo.Adapter:
                    DemoAdapter();
                break;
                
                case Demo.Composite:
                    DemoComposite();
                break;
                
                case Demo.Solid:
                    DemoSingleResponsability();
                    DemoOpenClose();
                    DemoLiskovSubstitution();
                    DemoDependencyInversion();
                break;

                case Demo.Builder:
                    DemoBuilder();
                break;
                
                case Demo.Factories:
                    DemoFactories();
                break;
                
                case Demo.Prototype:
                    DemoPrototype();
                break;
                
                case Demo.Singleton:      
                    DemoSingleton();
                break;
                
                case Demo.Bridge:      
                    DemoBridge();
                break;
            }
        }
        
        private static void DemoComposite(){
            WriteLine("Demo Composite...");
            
            var drawing = new Composite.GraphicObject { Name = "My Drawing"};
            drawing.Children.Add(new Composite.Square {Color = "Red"});
            drawing.Children.Add(new Composite.Circle {Color = "Yellow"});
            
            var group = new Composite.GraphicObject();
            group.Children.Add(new Composite.Circle {Color = "Blue"});
            group.Children.Add(new Composite.Square {Color = "Blue"});
            drawing.Children.Add(group);
            
            WriteLine(drawing);
            
            var neuron1 = new Composite.Neuron();
            var neuron2 = new Composite.Neuron();
            var layer1 = new Composite.NeuronLayer();
            var layer2 = new Composite.NeuronLayer();
            var layer3 = new Composite.NeuronLayer();
            
            
            neuron1.ConnectTo(neuron2);
            neuron1.ConnectTo(layer1);
            layer1.ConnectTo(layer2);
            neuron2.ConnectTo(layer3);
            
        }
        
        private static void DemoBridge(){
            WriteLine("Demo Bridge...");
            /*
            //Bridge.IRenderer renderer = new Bridge.RasterRenderer();
            Bridge.IRenderer renderer = new Bridge.VectorRenderer();
            var circle = new Bridge.Circle(renderer, 5);
            
            circle.Draw();
            circle.Resize(2);
            circle.Draw();
            */
           
            var cb = new ContainerBuilder();
            cb.RegisterType<Bridge.VectorRenderer>().As<Bridge.IRenderer>().SingleInstance();
            
            cb.Register((c,p) =>
                new Bridge.Circle(c.Resolve<Bridge.IRenderer>(), 
                p.Positional<float>(0)));
                
                using(var c = cb.Build())
                {
                    var circle = c.Resolve<Bridge.Circle>(
                        new PositionalParameter(0, 5.0f)
                    );
                    
                    circle.Draw();
                    circle.Resize(2.0f);
                    circle.Draw();
                }
        }
        
        private static void Draw(){
            foreach(var vo in vectorObjects){
                foreach(var line in vo){
                    var adapter = new Adapter.LineToPointAdapter(line);
                    adapter.ForEach(DrawPoint);
                }
            }
        }
        
        private static void DemoAdapter(){
            WriteLine("Demo Adapter...");       
            Draw();
            Draw();
        }
        
        public static void DrawPoint(Adapter.Point p){
            Write(".");
        }
        
        private static void DemoSingleton(){
            var db = Singleton.SingletonDatabase.Instance;
            var city = "Tokyo";
            WriteLine($"{city} has population {db.GetPopulation(city):N}");
            
            //Monostate
            var ceo = new Singleton.CEO();
            ceo.Name = "Adam Smith";
            ceo.Age = 55;
            
            var ceo2 = new Singleton.CEO();
            WriteLine(ceo2);
        }
        
        
        private static void DemoPrototype(){
            var john = new Prototype.Person(new []{"John", "Smith"}, 
                                            new Prototype.Address("London Road", 123));
            
            //var jane = john;
            //jane.Names[0] = "Jane";
            
            //var jane = (Prototype.Person)john.Clone();
            //var jane = new Prototype.Person(john);
            //var jane = john.DeepCopy();
            var jane = john.DeepCopyXml();
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 456;
            
            WriteLine(john);
            WriteLine(jane);
        }
        
        private static void DemoFactories(){
            var point = Factories.Point.Factory.NewPolarPoint(1.0, Math.PI /2);
            WriteLine(point);
            
            var machine = new Factories.HotDrinkMachine();
            //var drink = machine.MakeDrink(Factories.HotDrinkMachine.AvailableDrink.Tea, 100);
            //drink.Consume();
            
            var drink = machine.MakeDrink();
            drink.Consume();    
        }
        
        private static void DemoBuilder(){
            {
                var hello = "hello";
                var sb = new StringBuilder();
                sb.Append("<p>");
                sb.Append(hello);
                sb.Append("</p>");
                WriteLine(sb);
                
                var words = new [] {"Hello", "world"};
                sb.Clear();
                sb.Append("<ul>");
                foreach(var word in words)
                    sb.AppendFormat("<li>{0}</li>", word);
                
                sb.Append("</ul>");
                WriteLine(sb);
            }
                var builderHtml = new Builder.HtmlBuilder("ul");
                /*
                builderHtml.AddChild("li","Hello");
                builderHtml.AddChild("li","world!!");*/
                builderHtml.AddChild("li","Hello").AddChild("li","world!!");
                WriteLine(builderHtml.ToString());
             
            //Fluent builder Inheritance with Recursive Generics
            var me = Builder.Person.New
                .Called("Dmitri")
                .WorksAsA("quant")
                .Build();
            WriteLine(me);
            
            var employee = Builder.Employee
                                  .NewEmployee
                                  .SetName("Maks")
                                  .AtPosition("Software Developer")
                                  .WithSalary(3500)
                                  .Build();
            
            WriteLine(employee);
            
            //Faceted Buildergn            
            var ib = new Builder.IndividualBuilder();
            Builder.Individual individual = ib
                .BasicInfo.WihtFirstName("Luis")
                          .WihtLastName("Hernandez")
                          .WithAssignedId("ABC1234")
                          .WithDOB("20/07/1981")
                .Lives.At("Sta Fe")
                      .In("CDMX")
                      .WithPostCode("01279")
                .Works.At("TCS")
                      .AsA("Developer Sr")
                      .Earning(13000);
                      
            WriteLine(individual); 
        }
        
        
        private static void DemoDependencyInversion(){
            var parent = new Solid.Person { Name = "Jhon" };
            var child1 = new Solid.Person { Name = "Chris" };
            var child2 = new Solid.Person { Name = "Mary" };
            
            var relationsships = new Solid.Relationships();
            relationsships.AddParentAndChild(parent, child1);
            relationsships.AddParentAndChild(parent, child2);
            
            new Solid.Research(relationsships);
            
        }
        
        
        private static void DemoSingleResponsability() {
            var j = new Solid.Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            WriteLine(j);
            
            var p = new Solid.Persintence();
            var filename = "./temp/Journal.txt";
            
            p.SaveToFile(j, filename, true);
                            
            //Process.Start(filename);
            Process.Start("nano", filename + " -RL");
        }
        
        private static void DemoOpenClose(){
            var apple = new Solid.Product("Apple", Solid.Color.Green, Solid.Size.Small);
            var tree = new  Solid.Product("Tree", Solid.Color.Green, Solid.Size.Large);
            var house = new Solid.Product("House", Solid.Color.Blue, Solid.Size.Large);
            
            Solid.Product[] products = {apple, tree, house};
            
            var pf = new Solid.ProductFilter();
            WriteLine("Green products (old):");
            foreach(var p in pf.FilterByColor(products, Solid.Color.Green))
                WriteLine($"- {p.Name} is green");
            
            var bf = new Solid.BetterFilter();
            WriteLine("Green products (new):");
            foreach(var p in bf.Filter(products, new Solid.ColorSpecification(Solid.Color.Green)))
                WriteLine($"- {p.Name} is green");
            
            WriteLine("Large blue items:");
            foreach(var p in bf.Filter(
                products,
                new Solid.AndSpecification<Solid.Product>(
                    new Solid.ColorSpecification(Solid.Color.Blue),
                    new Solid.SizeSpecification(Solid.Size.Large)
                )))
                    WriteLine($"- {p.Name} is big and blue");
        }
        
        private static void DemoLiskovSubstitution(){
            Solid.Rectangule rc = new Solid.Rectangule(2,3);
            WriteLine($"{rc} has area {Area(rc)}");

            Solid.Rectangule sq = new Solid.Square();
            sq.Width = 4;
            WriteLine($"{sq} has area {Area(sq)}");
        }
    }
    
    [Flags]
    enum Demo {
        Solid     = 1,
        Builder   = 2,
        Factories = 3,
        Prototype = 4,
        Singleton = 5,
        Adapter   = 6,
        Bridge    = 7,
        Composite = 8
    }
}
