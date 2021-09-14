namespace Application.Models
{
    public class Account : IAccount
    {
        public string Owner { get; private set; }
        public double Balance { get; private set; }
        private double InterestRate { get; set; }

        public Account(string owner, double interestRate, double initialBalance)
        {
            if (string.IsNullOrEmpty(owner))
            {
                throw new ArgumentException("Owner cannot be empty or null");
            }

            if (interestRate < 0)
            {
                throw new ArgumentOutOfRangeException("Interest rate cannot be nagative");
            }

            if (initialBalance < 0)
            {
                throw new ArgumentOutOfRangeException("Initial balance cannot be negative");
            }


            Owner = owner;
            Balance = initialBalance;
            InterestRate = interestRate;
        }

        public double AddInterest()
        {
            throw new NotImplementedException();
        }

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Amount for deposit cannot be negative");
            }

            Balance += amount;

        }

        public void Withdraw(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Amount for withdraw cannot be negative");
            }

            if ((Balance - amount) < 0)
            {
                throw new InvalidOperationException("Unable to withdraw. Not enough resources.");
            }

            Balance -= amount;
        }
    }
}
