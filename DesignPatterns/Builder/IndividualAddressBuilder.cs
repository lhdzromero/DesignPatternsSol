namespace DesignPatterns.Builder
{
    public class IndividualAddressBuilder: IndividualBuilder
    {
        public IndividualAddressBuilder(Individual individual){
            this.individual = individual;
        }
        
        public IndividualAddressBuilder At(string streetAddress){
            individual.StreetAddress = streetAddress;
            
            return this;
        }
        
        public IndividualAddressBuilder WithPostCode(string postcode){
            individual.PostCode = postcode;
            
            return this;
        }
        
        public IndividualAddressBuilder In(string city){
            individual.City = city;
            
            return this;
        }
    }
}