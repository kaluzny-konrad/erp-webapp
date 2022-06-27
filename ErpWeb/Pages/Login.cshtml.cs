using ErpWeb.Controllers;
using ErpWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErpWeb.Pages
{
    public class LogInModel : BasePage
    {
        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public string? Password { get; set; }

        private readonly ILogInController _loginController;

        public LogInModel(
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
                return RedirectToPage("Index");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid && Email != null && Password != null)
                if (_loginController.LogIn(Email, Password))
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToPage("Index");
                }
            return Page();
        }
    }
}
