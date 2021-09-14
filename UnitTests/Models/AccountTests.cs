using Application.Models;
using Xunit;

namespace UnitTests.Models
{
    public class AccountTests
    {
        [Fact]
        public void Account_CreateAccount_ShouldCreateInstance()
        {
            var money = new Money
            {
                amount = 0
            };
            var account = new Account("jakub", 0, money);
            
            Assert.Equal("jakub", account.Owner);
            Assert.Equal(0, account.Balance.amount);
        }

        [Fact]
        public void Account_CreateAccountNonZeroBalance_ShouldCreateInstance()
        {
            var money = new Money
            {
                amount = 150.1
            };
            var account = new Account("jakub", 1.1, money);

            Assert.Equal("jakub", account.Owner);
            Assert.Equal(150.1, account.Balance.amount);
            Assert.Equal(1.1, account.InterestRate);
        }

        [Fact]
        public void Account_CreateAccountInvalidName_ShouldThrow()
        {
            var money = new Money
            {
                amount = 0
            };
            Assert.Throws<ArgumentException>(() =>
            {
                var account = new Account(string.Empty, 0, money);
            });
        }

        [Fact]
        public void Account_CreateAccountInvalidBalance_ShouldThrow()
        {
            var money = new Money
            {
                amount = -100
            };

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new Account("jakub", 0, money);
            });
        }

        [Fact]
        public void Account_CreateAccountInvalidRate_ShouldThrow()
        {
            var money = new Money
            {
                amount = 0
            };

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new Account("jakub", -10, money);
            });
        }

        [Fact]
        public void Deposit_DepositAmount_ShouldPass()
        {
            var money = new Money
            {
                amount = 0
            };

            var account = new Account("jakub", 0, money);

            var deposit = new Money
            {
                amount = 150
            };
            account.Deposit(deposit);

            Assert.Equal(150, account.Balance.amount);
        }

        [Fact]
        public void Deposit_DepositNegativeAmount_ShouldThrow()
        {
            var money = new Money
            {
                amount = 0
            };

            var account = new Account("jakub", 0, money);

            var deposit = new Money
            {
                amount = -150
            };

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                account.Deposit(deposit);
            });
        }
    }
}
