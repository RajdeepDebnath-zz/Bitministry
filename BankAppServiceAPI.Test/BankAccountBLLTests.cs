using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAppIRepository;
using Moq;
using DomainObjects;
using System.Collections.Generic;
using BankAppBLLLib;
using BankAppModels;

namespace BankAppBLL.Test
{
    [TestClass]
    public class BankAccountBLLTests
    {
        private IBankAccountBLL _bankAccountBLL;
        [TestMethod]
        public void GetAllUserNameTests()
        {
            //Arrange
            var listBankAccountModel = new List<BankAccountModel>();
            listBankAccountModel.Add(new BankAccountModel { UserName = "Raj" });
            listBankAccountModel.Add(new BankAccountModel { UserName = "abc" });
            listBankAccountModel.Add(new BankAccountModel { UserName = "xyz" });

            var listBankAccountDO = new List<BankAccountDO>();
            listBankAccountDO.Add(new BankAccountDO { UserName = "Raj" });
            listBankAccountDO.Add(new BankAccountDO { UserName = "abc" });
            listBankAccountDO.Add(new BankAccountDO { UserName = "xyz" });
            var mock = new Mock<IBankAccountRepository>();
            mock.Setup(x => x.GetBankAccountDOs()).Returns(listBankAccountDO);

            //Act
            _bankAccountBLL = new BankAccontBLL(mock.Object);

            //Assert
            Assert.AreEqual(_bankAccountBLL.GetAllBankAccounts().Count, 3);
            Assert.AreNotEqual(_bankAccountBLL.GetAllBankAccounts(), null);
            Assert.AreEqual(_bankAccountBLL.GetAllBankAccounts()[0].UserName, "Raj");
        }
    }
}
