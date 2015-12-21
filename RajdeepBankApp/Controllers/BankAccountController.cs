using BankAppBLLLib;
using BankAppModels;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace BankAppServiceAPI.Controllers
{
    public class BankAccountController : ApiController
    {
        private IBankAccountBLL _bankAppBLL;
        public BankAccountController()
        {
            _bankAppBLL = new BankAccontBLL();
        }
        public BankAccountController(IBankAccountBLL bankAppBLL)
        {
            _bankAppBLL = bankAppBLL;
        }
        [HttpGet]
        public List<BankAccountModel> GetUserNames([FromUri]string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                return _bankAppBLL.GetAllBankAccounts().Where(user => user.UserName != userName).ToList<BankAccountModel>();
            }

            return new List<BankAccountModel>();

        }
        [HttpGet]
        public List<BankAccountModel> Get()
        {
            return _bankAppBLL.GetAllBankAccounts();

        }
    }
}
