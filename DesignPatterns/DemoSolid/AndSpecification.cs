using System;
namespace DesignPatterns.Solid
{
    public class AndSpecification<T> : ISpecification<T>
    {
        ISpecification<T> first, second;
        
        public AndSpecification(ISpecification<T> first, ISpecification<T> second){
            this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
            this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));
        }
        
        public bool IsSatisfied(T t){
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }
}