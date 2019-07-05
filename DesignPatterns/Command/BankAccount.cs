namespace DesignPatterns.Command
{
    public class BankAccount
    {
        private int balance;
        private int overdraftLimit = -500;

        public void Deposit(int amount){
            balance += amount;
            System.Console.WriteLine($"Deposited ${amount}, balance is now {balance}");
        }

        public bool Withdraw(int amount){
            if(balance - amount >= overdraftLimit)
            {
                balance -= amount;
                System.Console.WriteLine($"Withdrew ${amount}, balance is now {balance}");
                return true;             
            }
            return false;

        }

        public override string ToString(){
            return $"{nameof(balance)}: {balance}";
        }
    }
}