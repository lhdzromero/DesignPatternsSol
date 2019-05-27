namespace DesignPatterns.Builder
{
    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        
        public class EmployeeBuilderDirector: 
                     EmployeeSalaryBuilder<EmployeeBuilderDirector>
        {
            
        }
        
        public static EmployeeBuilderDirector NewEmployee => new EmployeeBuilderDirector();
                
        public override string ToString(){
            return $"Name: {Name}, Position: {Position}, Salary: {Salary}";
        }
    }
}