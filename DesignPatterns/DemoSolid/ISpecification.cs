namespace DesignPatterns.Solid
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
}