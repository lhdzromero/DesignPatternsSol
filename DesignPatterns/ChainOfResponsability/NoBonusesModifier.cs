namespace DesignPatterns.ChainOfResponsability
{
    public class NoBonusesModifier : CreatureModifier
    {
        public NoBonusesModifier(Creature creature) : base(creature){}

        public override void Handle(){
            //Nothing here
        }
    }
}