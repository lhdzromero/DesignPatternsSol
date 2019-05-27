using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

//Copy Through Serialization
namespace DesignPatterns
{
    public static class ExtensionsMethods
    {
        public static T DeepCopy<T>(this T self){
            var stream = new MemoryStream();
            var formater = new BinaryFormatter();
            formater.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formater.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }

        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T) s.Deserialize(ms);
            }       
        }
    }
}

namespace DesignPatterns.Prototype
{
    /*
    public interface IPrototype<T>
    {
        T DeepCopy();
    }
    */
   
    //[Serializable]
    public class Person  //: IPrototype<Person> //ICloneable
    {
        public string[] Names;
        public Address Address;
        
        public Person(){}
        
        public Person(string[] names, Address address){
            if(names == null)
                throw new ArgumentNullException(paramName: nameof(names));
            if(address == null)
                throw new ArgumentNullException(paramName: nameof(address));
            
            Names = names;
            Address = address;
        }
        
        public Person(Prototype.Person other){
            Names = other.Names;
            Address = new Address(other.Address);
        }

        public override string ToString(){
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
        
        /*
        public object Clone(){
            return new Person(Names, (Address)Address.Clone());
        }
       
       
       public Prototype.Person DeepCopy(){
           return new Prototype.Person(Names, Address.DeepCopy());
       }
        */
    }

    //[Serializable]
    public class Address //: IPrototype<Address> //ICloneable
    {
        public string StreetName;
        public int HouseNumber;
        
        public Address(){}
        
        public Address(string streetName, int houseNumber){
            if(streetName == null)
                throw new ArgumentNullException(paramName: nameof(streetName));
                
            StreetName = streetName;
            HouseNumber = houseNumber;
        }
        
        //Copy constructor
        public Address(Prototype.Address other){
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }
        
        public override string ToString(){
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
        
        /*
       public object Clone(){
           return new Address(StreetName, HouseNumber);
       }
       
       public Prototype.Address DeepCopy(){
          return new Prototype.Address(StreetName, HouseNumber);
       }
       */        
    }
}