using System;

namespace DesignPatterns.ChainOfResponsability
{
    public class Creature
    {
        public string Name;
        public int Attact, Defense;

        public Creature(string name, int attack, int defense)
        {
            this.Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            this.Attact = attack;
            this.Defense = defense;
        }

        public override string ToString(){
            return $"{nameof(Name)}: {Name}, {nameof(Attact)}: {Attact}, {nameof(Defense)}: {Defense}";
        }      
    }
}