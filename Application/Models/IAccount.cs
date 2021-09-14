namespace Application.Models
{
    public interface IAccount
    {
        public IMoney Balance { get; }

        public void Deposit(IMoney amount);

        public void Withdraw(IMoney amount);

        public void AddInterest();
    }
}
