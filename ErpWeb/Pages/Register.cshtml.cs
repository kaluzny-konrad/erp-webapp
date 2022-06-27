using ErpWeb.Controllers;
using ErpWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErpWeb.Pages
{
    public class RegisterModel : BasePage
    {
        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public string? Password { get; set; }

        public RegisterModel(
            ILogger<BasePage> logger,
            IHttpContextAccessor httpContextAccessor,
            IUserService userService)
        : base(logger, httpContextAccessor, userService) { }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Email != null && Password != null)
                if (RegisterController.RegisterUser(Email, Password))
                {
                    _logger.LogInformation("User registered.");
                    return RedirectToPage("RegisterConfirmation",
                        new { email = Email });
                }
            return Page();
        }
    }
}
