using System;
namespace DesignPatterns.ChainOfResponsability
{
    public abstract class CreatureModifierDos : IDisposable
    {
        protected Game game;
        protected CreatureDos creature;

        public CreatureModifierDos(Game game, CreatureDos creature)
        {
            this.game = game ?? throw new ArgumentNullException(paramName: nameof(game));
            this.creature = creature ?? throw new ArgumentNullException(paramName: nameof(creature));
            game.Queries += Handle;
        }

        protected abstract void Handle(object sender, Query q);

        public void Dispose(){
            game.Queries -= Handle;
        }
    }
}