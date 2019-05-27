namespace DesignPatterns.Builder
{
    public class PersonInfoBuilder<SELF>
        :PersonBuilder
        where SELF: PersonInfoBuilder<SELF>
    {
        //protected Person person = new Person();
        
        public SELF Called(string name){
            person.Name = name;
            return (SELF)this;
        }
    }
}