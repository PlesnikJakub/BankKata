namespace Application.Models
{
    public interface IAccount
    {
        public double Balance { get; }

        public void Deposit(double amount);

        public void Withdraw(double amount);

        public double AddInterest();
    }
}
