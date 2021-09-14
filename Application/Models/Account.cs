namespace Application.Models
{
    public class Account : IAccount
    {
        public string Owner { get; private set; }
        public IMoney Balance { get; private set; }
        public double InterestRate { get; private set; }

        public Account(string owner, double interestRate, IMoney initialBalance)
        {
            if (string.IsNullOrEmpty(owner))
            {
                throw new ArgumentException("Owner cannot be empty or null");
            }

            if (interestRate < 0)
            {
                throw new ArgumentOutOfRangeException("Interest rate cannot be nagative");
            }

            if (initialBalance.amount < 0)
            {
                throw new ArgumentOutOfRangeException("Initial balance cannot be negative");
            }


            Owner = owner;
            Balance = initialBalance;
            InterestRate = interestRate;
        }

        public void AddInterest()
        {
            throw new NotImplementedException();
        }

        public void Deposit(IMoney money)
        {
            if (money.amount < 0)
            {
                throw new ArgumentOutOfRangeException("Amount for deposit cannot be negative");
            }

            Balance.amount += money.amount;

        }

        public void Withdraw(IMoney money)
        {
            if (money.amount < 0)
            {
                throw new ArgumentOutOfRangeException("Amount for withdraw cannot be negative");
            }

            if ((Balance.amount - money.amount) < 0)
            {
                throw new InvalidOperationException("Unable to withdraw. Not enough resources.");
            }

            Balance.amount -= money.amount;
        }
    }
}
