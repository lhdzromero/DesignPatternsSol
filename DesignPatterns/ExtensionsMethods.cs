using System;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesignPatterns
{
    public static class ExtensionsMethods
    {        
        //Copy Through Serialization 
        //Metodos de estension para Prototype.Person
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
        
        //Metodo de extension para Composite.Neuron
        public static void ConnectTo(this IEnumerable<Composite.Neuron> self, IEnumerable<Composite.Neuron> other){           
            if(ReferenceEquals(self, other)) return;
            
            foreach(var from in self) 
            foreach(var to in other)
            {
                if(from.Out == null) return;
                
                from.Out.Add(to);
                to.In.Add(from);
            }
        }
    }
}
