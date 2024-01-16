using Allure.Xunit.Attributes;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnitBL.ObjectMothers;
using Xunit;

namespace UnitTests.UnitTestsDA
{
    [AllureOwner("Quang")]
    [AllureSuite("Account DataAccess Unit Tests")]
    [Collection("DBCollection")]
    public class AccountDAUnitTests : IDisposable
    {
        private DBFixture fixture;
        public AccountDAUnitTests(DBFixture _dbFixture)
        {
            fixture = _dbFixture;
        }
        public void Dispose() { }

        [AllureXunit]
        public async void TestAddAccount()
        {
            //Arrange
            int id_account = 3;
            Account account = AccountOM.CreateUser(id_account).buildBL();
            int count = fixture.context.Accounts.Count() + 1;
            //Action
            fixture.accountDA.addAccount(account);
            //Assert
            Assert.Equal(count, fixture.context.Accounts.Count());
        }

        [AllureXunit]
        public void TestGetIdAccount()
        {
            //Arrange
            int id_account = 2;
            string login = "admin2";
            //Action
            int result = fixture.accountDA.getIdAccount(login);
            //Assert
            Assert.Equal(id_account, result);
        }

        [AllureXunit]
        public void TestGetAccount()
        {
            //Arrange
            int id_account = 1;
            //Action
            var result = fixture.accountDA.getAccount(id_account);
            //Assert
            Assert.Equal(id_account, result.Id);
        }

        [AllureXunit]
        public async void TestDeleteAccount()
        {
            //Arrange
            int id_account = 1;
            int count = fixture.context.Accounts.Count() - 1;
            //Action
            fixture.accountDA.deleteAccount(id_account);
            //Assert
            Assert.Equal(count, fixture.context.Accounts.Count());
        }

        [AllureXunit]
        public async void TestGetAllAccount()
        {
            //Arrange
            int count = fixture.context.Accounts.Count();
            //Action
            var result = fixture.accountDA.getAllAccount();
            //Assert
            Assert.Equal(count, result.Count);
        }
    }
}
