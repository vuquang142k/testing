using Allure.Xunit.Attributes;
using BL.Models;
using System.Security.Principal;
using TestUnitBL.ObjectMothers;
using Xunit;

namespace IntegrationTests
{
    [AllureOwner("Quang")]
    [AllureSuite("Account Integration Tests")]
    [Collection("ITCollection")]
    public class InteTestAccount : IDisposable
    {
        private readonly ITFixture _fixture;
        public InteTestAccount(ITFixture fixture)
        {
            _fixture = fixture;
        }

        public void Dispose(){}

        [AllureXunit]
        public void TestAddAccount()
        {
            //Arrange
            int id_user = 3;
            string login = "user1";
            Account newAccount = AccountOM.CreateUser(id_user).buildBL();
            //Action
            int id_newAccount = _fixture.accountServices.addAccount(newAccount);
            //Assert
            Assert.Equal(newAccount.Id, id_newAccount);
            _fixture.accountServices.deleteAccount(id_user);
        }
        [AllureXunit]
        public void TestGetIdAccount()
        {
            //Arrange
            string login = "user";
            //Action
            int id = _fixture.accountServices.getIdAccount(login);
            //Assert
            Assert.Equal(1, id);
        }
        [AllureXunit]
        public void TestGetAccount()
        {
            //Arrange
            int id_user = 1;
            
            //Action
            Account user = _fixture.accountServices.getAccount(id_user);
            //Assert
            Assert.Equal(1, user.Id);
        }
        [AllureXunit]
        public void TestDeleteAccount()
        {
            //Arrange
            int id_user = 3;
            Account newAccount = AccountOM.CreateUser(id_user).buildBL();
            //Action
            _fixture.accountServices.addAccount(newAccount);
            int id_newAccount = _fixture.accountServices.deleteAccount(id_user);
            //Assert
            Assert.Equal(3, id_newAccount);
        }
        [AllureXunit]
        public void TestAccountGetAll()
        {
            //Action
            List<Account> result = _fixture.accountServices.getAllAccount();

            //Assert
            Assert.Equal(2, result.Count);
            Assert.All(result, item => Assert.InRange(item.Id, low: 1, high: 2));
        }
    }
}
