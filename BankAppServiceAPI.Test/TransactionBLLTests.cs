using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAppBLLLib;
using BankAppModels;
using System.Collections.Generic;
using DomainObjects;
using BankAppIRepository;
using Moq;

namespace BankAppServiceAPI.Test
{
    [TestClass]
    public class TransactionBLLTests
    {
        private ITransactionBLL _transactionBLL;
        [TestMethod]
        public void GetBalanceTests()
        {
            //Arrange
            string userName = "test";
            var listTransactionModel = new List<TransactionModel>();
            listTransactionModel.Add(new TransactionModel { UserName = "test", Amount = 1000 });
            listTransactionModel.Add(new TransactionModel { UserName = "abc", Amount = 2000 });
            listTransactionModel.Add(new TransactionModel { UserName = "xyz", Amount = 3000 });
            listTransactionModel.Add(new TransactionModel { UserName = "test", Amount = 3000 });

            var listTransactionDO = new List<TransactionDO>();
            listTransactionDO.Add(new TransactionDO { UserName = "test", Amount = 1000 });
            listTransactionDO.Add(new TransactionDO { UserName = "abc", Amount = 2000 });
            listTransactionDO.Add(new TransactionDO { UserName = "xyz", Amount = 3000 });
            listTransactionDO.Add(new TransactionDO { UserName = "test", Amount = 3000 });
            var mock = new Mock<ITransactionRepository>();
            mock.Setup(x => x.GetTransactionDOsByUserName(userName)).Returns(listTransactionDO.Where(x => x.UserName == userName).ToList<TransactionDO>());

            //Act
            _transactionBLL = new TransactionBLL(mock.Object);

            //Assert
            Assert.AreEqual(_transactionBLL.GetBalance(userName), 4000);
        }

        [TestMethod]
        public void WithdrawTests()
        {
            //Arrange
            string userName = "test";
            int amount = 100;
            var mock = new Mock<ITransactionRepository>();
            mock.Setup(x => x.SaveNewTransaction(userName, -1*amount)).Returns(1);

            //Act
            _transactionBLL = new TransactionBLL(mock.Object);

            //Assert
            Assert.AreEqual(_transactionBLL.Withdraw(userName, amount), 1);
        }


        [TestMethod]
        public void DepositTests()
        {
            //Arrange
            string userName = "test";
            int amount = 100;
            var mock = new Mock<ITransactionRepository>();
            mock.Setup(x => x.SaveNewTransaction(userName, amount)).Returns(1);

            //Act
            _transactionBLL = new TransactionBLL(mock.Object);

            //Assert
            Assert.AreEqual(_transactionBLL.Deposit(userName, amount), 1);
        }
        [TestMethod]
        public void TransferTests()
        {
            //Arrange
            string userName = "test";
            int amount = 100;
            var mock = new Mock<ITransactionRepository>();
            mock.Setup(x => x.Transfer(userName, userName, -1*amount, amount)).Returns(1);

            //Act
            _transactionBLL = new TransactionBLL(mock.Object);

            //Assert
            Assert.AreEqual(_transactionBLL.Transfer(userName, userName, amount), 1);
        }
        [TestMethod]
        public void GetAllTransactionTests()
        {
            //Arrange
            string userName = "test";
            var listTransactionModel = new List<TransactionModel>();
            listTransactionModel.Add(new TransactionModel { UserName = "test", Amount = 1000 });
            listTransactionModel.Add(new TransactionModel { UserName = "abc", Amount = 2000 });
            listTransactionModel.Add(new TransactionModel { UserName = "xyz", Amount = 3000 });
            listTransactionModel.Add(new TransactionModel { UserName = "test", Amount = 3000 });

            var listTransactionDO = new List<TransactionDO>();
            listTransactionDO.Add(new TransactionDO { UserName = "test", Amount = 1000 });
            listTransactionDO.Add(new TransactionDO { UserName = "abc", Amount = 2000 });
            listTransactionDO.Add(new TransactionDO { UserName = "xyz", Amount = 3000 });
            listTransactionDO.Add(new TransactionDO { UserName = "test", Amount = 3000 });
            var mock = new Mock<ITransactionRepository>();
            mock.Setup(x => x.GetAllTransactionDOs()).Returns(listTransactionDO);

            //Act
            _transactionBLL = new TransactionBLL(mock.Object);

            //Assert
            Assert.AreNotEqual(_transactionBLL.GetAllTransaction(), null);
            Assert.AreEqual(_transactionBLL.GetAllTransaction().Count, 4);
            Assert.AreEqual(_transactionBLL.GetAllTransaction()[0].Amount, 1000);
        }
        [TestMethod]
        public void GetTransactionByUserNameTests()
        {
            //Arrange
            string userName = "test";
            var listTransactionModel = new List<TransactionModel>();
            listTransactionModel.Add(new TransactionModel { UserName = "test", Amount = 1000 });
            listTransactionModel.Add(new TransactionModel { UserName = "abc", Amount = 2000 });
            listTransactionModel.Add(new TransactionModel { UserName = "xyz", Amount = 3000 });
            listTransactionModel.Add(new TransactionModel { UserName = "test", Amount = 3000 });

            var listTransactionDO = new List<TransactionDO>();
            listTransactionDO.Add(new TransactionDO { UserName = "test", Amount = 1000 });
            listTransactionDO.Add(new TransactionDO { UserName = "abc", Amount = 2000 });
            listTransactionDO.Add(new TransactionDO { UserName = "xyz", Amount = 3000 });
            listTransactionDO.Add(new TransactionDO { UserName = "test", Amount = 3000 });
            var mock = new Mock<ITransactionRepository>();
            mock.Setup(x => x.GetTransactionDOsByUserName(userName)).Returns(listTransactionDO.Where(x => x.UserName == userName).ToList<TransactionDO>());

            //Act
            _transactionBLL = new TransactionBLL(mock.Object);

            //Assert
            Assert.AreNotEqual(_transactionBLL.GetTransactionByUserName(userName), null);
            Assert.AreEqual(_transactionBLL.GetTransactionByUserName(userName).Count, 2);
            Assert.AreEqual(_transactionBLL.GetTransactionByUserName(userName)[0].Amount, 1000);
        }
    }
}
