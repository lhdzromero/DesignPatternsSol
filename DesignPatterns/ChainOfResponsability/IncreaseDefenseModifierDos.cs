namespace DesignPatterns.ChainOfResponsability
{
    public class IncreaseDefenseModifierDos : CreatureModifierDos
    {
        public IncreaseDefenseModifierDos(Game game, CreatureDos creature) : base(game, creature)
        {
        }

        protected override void Handle(object sender, Query q){
            if(q.CreatureName == creature.Name && q.WhatToQuery == Query.Argument.Defense)
                q.Value += 2;
        }
    }
}