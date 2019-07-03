using System;
namespace DesignPatterns.ChainOfResponsability
{
    public class CreatureDos
    {
        private Game game;
        public string Name;
        private int attack, defense;

        public CreatureDos(Game game, string name, int attack, int defense)
        {
            this.game = game ?? throw new ArgumentNullException(paramName: nameof(game));
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            this.attack = attack;
            this.defense = defense;
        }

        public int Attack
        {
            get 
            {
                var q = new Query(Name, Query.Argument.Attack, attack);
                game.PerformQuery(this,q); //q.Value;
                return q.Value;
            }
        }

        public int Defense
        {
            get 
            {
                var q = new Query(Name, Query.Argument.Defense, defense);
                game.PerformQuery(this,q); //q.Value;
                return q.Value;
            }
        }

        public override string ToString(){
            return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
        }
    }
}