using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAppIRepository;
using Moq;
using DomainObjects;
using System.Collections.Generic;
using BankAppBLLLib;

namespace BankAppBLL.Test
{
    [TestClass]
    public class BankAccountBLLTests
    {
        private IBankAccountBLL _bankAccountBLL;
        public BankAccountBLLTests()
        {
        }
        [TestMethod]
        public void GetAllUserNameTests()
        {
            //Arrange
            var listBankAccountDO = new List<BankAccountDO>();
            listBankAccountDO.Add(new BankAccountDO { UserName = "Raj" });
            listBankAccountDO.Add(new BankAccountDO { UserName = "abc" });
            listBankAccountDO.Add(new BankAccountDO { UserName = "xyz" });
            var mock = new Mock<IBankAccountRepository>();
            mock.Setup(x => x.GetBankAccountDOs()).Returns(listBankAccountDO);

            //Act
            _bankAccountBLL = new BankAccontBLL(mock.Object);

            //Assert
            Assert.AreEqual(mock.Object.GetBankAccountDOs(), true);
        }
    }
}
