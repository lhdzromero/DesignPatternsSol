namespace DesignPatterns.ChainOfResponsability
{
    public class DoubleAttackModifierDos : CreatureModifierDos
    {
        public DoubleAttackModifierDos(Game game, CreatureDos creature) : base(game, creature)
        {
        }

        protected override void Handle(object sender, Query q){
            if(q.CreatureName == creature.Name && q.WhatToQuery == Query.Argument.Attack)
                q.Value *= 2;
        }
    }
}