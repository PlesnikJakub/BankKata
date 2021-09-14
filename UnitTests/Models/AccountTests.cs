using Application.Models;
using Xunit;

namespace UnitTests.Models
{
    public class AccountTests
    {
        [Fact]
        public void Account_CreateAccount_ShouldCreateInstance()
        {
            var account = new Account("jakub", 0, 0);
            
            Assert.Equal("jakub", account.Owner);
            Assert.Equal(0, account.Balance);
        }

        [Fact]
        public void Account_CreateAccountNonZeroBalance_ShouldCreateInstance()
        {
            var account = new Account("jakub", 1.1, 150.1);

            Assert.Equal("jakub", account.Owner);
            Assert.Equal(150.1, account.Balance);
            Assert.Equal(1.1, account.InterestRate);
        }

        [Fact]
        public void Account_CreateAccountInvalidName_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var account = new Account(string.Empty, 0, 0);
            });
        }

        [Fact]
        public void Account_CreateAccountInvalidBalance_ShouldThrow()
        {

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new Account("jakub", 0, -100);
            });
        }

        [Fact]
        public void Account_CreateAccountInvalidRate_ShouldThrow()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new Account("jakub", -10, 0);
            });
        }
    }
}
