namespace DesignPatterns.Builder
{
    //Facade
    public class IndividualBuilder
    {
        //Reference
        protected Individual individual = new Individual();
        
        public IndividualJobBuilder Works => new IndividualJobBuilder(individual);
        
        public IndividualAddressBuilder Lives => new IndividualAddressBuilder(individual);
        
        public IndividualInfoBuilder BasicInfo => new IndividualInfoBuilder(individual);
        
        
        public static implicit operator Individual(IndividualBuilder ib){
            return ib.individual;
        }
        
    }
}