namespace DesignPatterns.Builder
{
    public class IndividualInfoBuilder: IndividualBuilder
    {
        public IndividualInfoBuilder(Individual individual){
            this.individual = individual;
        }
        
        public IndividualInfoBuilder WihtFirstName(string firstname){
            individual.FirstName = firstname;
            
            return this;
        }
        
        public IndividualInfoBuilder WihtLastName(string lastname){
            individual.LastName = lastname;
            
            return this;
        }
        
        
        public IndividualInfoBuilder WithAssignedId(string id){
            individual.Id = id;
            
            return this;
        }
        
        public IndividualInfoBuilder WithDOB(string birthday){
            individual.BirthDay = birthday;

            individual.CalcAge();

            return this;
        }      
    }
}