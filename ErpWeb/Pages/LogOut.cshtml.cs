using ErpWeb.Controllers;
using ErpWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErpWeb.Pages
{
    public class LogOutModel : BasePage
    {
        private readonly ILogInController _loginController;

        public LogOutModel(
            ILogger<BasePage> logger, 
            IHttpContextAccessor httpContextAccessor, 
            IUserService userService) 
        : base(logger, httpContextAccessor, userService)
        {
            _loginController = new LoginController(_userService);
        }

        public IActionResult OnGet()
        {
            if (_userService.IsLoggedIn())
                _loginController.LogOut();
            return RedirectToPage("Index");
        }
    }
}
