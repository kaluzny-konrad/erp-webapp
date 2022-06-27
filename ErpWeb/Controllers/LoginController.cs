using ErpService.Account;
using ErpWeb.Pages;
using ErpWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErpWeb.Controllers
{
    public interface ILogInController
    {
        bool LogIn(string email, string password);
        void LogOut();
    }

    public class LoginController : Controller, ILogInController
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        public bool LogIn(string email, string password)
        {
            var accountDb = AccountDbJson.GetDb();
            var accountManager = AccountManager.GetManager(accountDb);
            if (accountManager.LoginToAccount(email, password))
            {
                _userService.SetEmail(email);
                return true;
            }
            return false;
        }

        public void LogOut()
        {
            if (_userService.IsLoggedIn())
                _userService.SetEmail("");
        }
    }
}
