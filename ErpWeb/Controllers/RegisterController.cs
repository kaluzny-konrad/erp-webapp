using ErpService.Account;
using Microsoft.AspNetCore.Mvc;

namespace ErpWeb.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public static bool RegisterUser(string email, string password)
        {
            if (email != null && password != null)
            {
                var accountDb = AccountDbJson.GetDb();
                var accountManager = AccountManager.GetManager(accountDb);
                return accountManager.NewAccount(email, password);
                
            }
            return false;
        }
    }
}
