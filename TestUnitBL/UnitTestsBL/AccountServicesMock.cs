using Allure.Xunit.Attributes;
using BL.BL;
using BL.Error;
using BL.InterfaceDB;
using BL.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TestUnitBL.ObjectMothers;
using Xunit;

namespace UnitTests.UnitTestsBL.Mock
{
    [AllureOwner("Quang")]
    [AllureSuite("Account Services Unit Tests")]
    public class AccountServicesMock
    {
        private List<Account> accounts;
        public AccountServicesMock()
        {
            Account user1 = AccountOM.CreateUser(1).buildBL();
            Account user2 = AccountOM.CreateAdmin(2).buildBL();
            accounts = new List<Account>() { user1, user2};
        }

        [AllureXunit]
        public void TestAddAccount()
        {
            //Arrange
            int id_user = 3;
            string login = "user3";
            Account newAccount = AccountOM.CreateUser(id_user).buildBL();
            var mockIAccountDB = new Mock<IAccountDB>();
            mockIAccountDB.Setup(repo => repo.getIdAccount(login))
                .Returns(-1);
            mockIAccountDB.Setup(repo => repo.addAccount(newAccount))
                .Returns(id_user);
            AccountServices userServices = new AccountServices(mockIAccountDB.Object);
            //Action
            int id_newAccount = userServices.addAccount(newAccount);
            //Assert
            mockIAccountDB.Verify(repo => repo.getIdAccount(login), Times.Once);
            mockIAccountDB.Verify(repo => repo.addAccount(newAccount), Times.Once);
            Assert.Equal(newAccount.Id, id_newAccount);
        }
        [AllureXunit]
        public void TestAddExistsAccount()
        {
            //Arrange
            int id_user = 1;
            Account newAccount = AccountOM.CreateUser(id_user).buildBL();
            var mockIAccountDB = new Mock<IAccountDB>();
            mockIAccountDB.Setup(repo => repo.getAccount(newAccount.Id))
                .Returns(newAccount);
            AccountServices userServices = new AccountServices(mockIAccountDB.Object);
            //Action & Assert
            Assert.Throws<AccountExistsException>(() => userServices.addAccount(newAccount));
        }
        [AllureXunit]
        public void TestGetIdAccount()
        {
            //Arrange
            string login = "user1";
            var mockIAccountDB = new Mock<IAccountDB>();
            mockIAccountDB.Setup(repo => repo.getIdAccount(login))
                .Returns(accounts.Where(s => s.Login == login).FirstOrDefault().Id);
            AccountServices userServices = new AccountServices(mockIAccountDB.Object);
            //Action
            int id = userServices.getIdAccount(login);
            //Assert
            mockIAccountDB.Verify(repo => repo.getIdAccount(login), Times.Once);
            Assert.Equal(1, id);
        }
        [AllureXunit]
        public void TestGetAccount()
        {
            //Arrange
            int id_user = 1;
            var mockIAccountDB = new Mock<IAccountDB>();
            mockIAccountDB.Setup(repo => repo.getAccount(id_user))
                .Returns(accounts.Where(s => s.Id == id_user).FirstOrDefault());
            AccountServices userServices = new AccountServices(mockIAccountDB.Object);
            //Action
            Account user = userServices.getAccount(id_user);
            //Assert
            mockIAccountDB.Verify(repo => repo.getAccount(id_user), Times.Once);
            Assert.Equal(1, user.Id);
        }
        [AllureXunit]
        public void TestDeleteAccount()
        {
            //Arrange
            int id_user = 1;
            var mockIAccountDB = new Mock<IAccountDB>();
            mockIAccountDB.Setup(repo => repo.deleteAccount(id_user))
                .Returns(id_user);
            mockIAccountDB.Setup(repo => repo.getAccount(id_user))
                .Returns(accounts.Where(s => s.Id == id_user).FirstOrDefault());
            AccountServices userServices = new AccountServices(mockIAccountDB.Object);
            //Action
            int id_newAccount = userServices.deleteAccount(id_user);
            //Assert
            mockIAccountDB.Verify(repo => repo.deleteAccount(id_user), Times.Once);
            mockIAccountDB.Verify(repo => repo.getAccount(id_user), Times.Once);
            Assert.Equal(1, id_newAccount);
        }
        [AllureXunit]
        public void TestAccountGetAll()
        {
            // Arrange
            var mockIAccountDB = new Mock<IAccountDB>();
            mockIAccountDB.Setup(repo => repo.getAllAccount()).Returns(accounts);
            AccountServices userServices = new AccountServices(mockIAccountDB.Object);

            //Action
            List<Account> result = userServices.getAllAccount();

            //Assert
            mockIAccountDB.Verify(repo => repo.getAllAccount(), Times.Once);
            Assert.Equal(2, result.Count);
            Assert.All(result, item => Assert.InRange(item.Id, low: 1, high: 2));
        }
    }
}
