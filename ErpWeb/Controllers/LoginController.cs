using ErpService.Account;
using Microsoft.AspNetCore.Mvc;

namespace ErpWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public static bool LoginUser(string email, string password)
        {
            if (email != null && password != null)
            {
                var accountDb = AccountDbJson.GetDb();
                var accountManager = AccountManager.GetManager(accountDb);
                return accountManager.LoginToAccount(email, password);
            }
            return false;
        }
    }
}
