using System;
using System.Globalization;

namespace DesignPatterns.Builder
{
    public class Individual
    {
        
        //Info
        public string FirstName, LastName, Id, BirthDay;
        private int AgeOf;
        
        //Address
        public string StreetAddress, PostCode, City;

        //Employment
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            
            return $"Basic Info: {Environment.NewLine}\t {nameof(Id)}: {Id} {Environment.NewLine}\t Full Name: {FirstName}, {LastName} {Environment.NewLine}\t {nameof(BirthDay)}: {BirthDay}  {nameof(AgeOf)}: {AgeOf} {Environment.NewLine} Address Info: {Environment.NewLine}\t {nameof(StreetAddress)}: {StreetAddress} {Environment.NewLine}\t {nameof(PostCode)}: {PostCode} {Environment.NewLine}\t {nameof(City)}: {City} {Environment.NewLine} Employment Info: {Environment.NewLine}\t {nameof(CompanyName)}: {CompanyName} {Environment.NewLine}\t {nameof(Position)}: {Position} {Environment.NewLine}\t {nameof(AnnualIncome)}: {AnnualIncome}";
        }
        
        public void CalcAge(){
            CultureInfo provider = CultureInfo.InvariantCulture; 
        
            DateTime dob = DateTime.ParseExact(this.BirthDay, "dd/MM/yyyy", provider);
            
            this.AgeOf = DateTime.Now.Year - dob.Year;          
        }
    }
}
