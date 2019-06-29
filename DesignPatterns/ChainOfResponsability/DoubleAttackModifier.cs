using System;

namespace DesignPatterns.ChainOfResponsability
{
    class DoubleAttackModifier : CreatureModifier
    {
       public DoubleAttackModifier(Creature creature) : base(creature){}

       public override void Handle(){
           Console.WriteLine($"Doubling {creature.Name}'s attack");
           creature.Attact *= 2;
           base.Handle();
       }

    }
}