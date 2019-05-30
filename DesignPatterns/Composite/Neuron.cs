using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesignPatterns.Composite
{
    public class Neuron : IEnumerable<Neuron>
    {
        public float Value;
        public List<Neuron> In, Out;
        
        /*
        public void ConnectTo(Neuron other){
            Out.Add(other);
            other.In.Add(this);
        }
        */

        public IEnumerator<Neuron> GetEnumerator(){
            yield return this;
        }
        
        IEnumerator IEnumerable.GetEnumerator(){
            return GetEnumerator();
             //yield return this;
        }
        
    }
}