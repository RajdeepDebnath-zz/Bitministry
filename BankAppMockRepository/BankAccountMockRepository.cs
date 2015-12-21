using DomainObjects;
using System.Collections.Generic;
using BankAppIRepository;
using Moq;

namespace BankAppMockRepository
{
    public class BankAccountMockRepository : IBankAccountRepository
    {
        public List<BankAccountDO> GetBankAccountDOs()
        {

            var mock = new Mock<TestClass>();
            mock.Setup(x => x.Hello()).Returns(true);
            Assert.AreEqual(mock.Object.Hello(), true);
            return null;
        }
    }
}
