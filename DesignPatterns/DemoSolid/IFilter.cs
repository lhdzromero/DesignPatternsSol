using System.Collections.Generic;

namespace DesignPatterns.Solid
{
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }
}