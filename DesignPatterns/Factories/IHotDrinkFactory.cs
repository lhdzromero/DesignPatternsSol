namespace DesignPatterns.Factories
{
    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }
}