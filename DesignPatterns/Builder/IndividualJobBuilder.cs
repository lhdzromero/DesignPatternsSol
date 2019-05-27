namespace DesignPatterns.Builder
{
    public class IndividualJobBuilder: IndividualBuilder
    {
        public IndividualJobBuilder(Individual individual){
            this.individual = individual;
        }
        
        public IndividualJobBuilder At(string companyname){
            individual.CompanyName = companyname;
           
           return this;
        }
        
        public IndividualJobBuilder AsA(string position){
            individual.Position = position;
           
           return this;
        }

        public IndividualJobBuilder Earning(int amount){
           individual.AnnualIncome = amount;
           
           return this;
        } 
    }
}