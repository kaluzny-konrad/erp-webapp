using ErpWeb.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErpWeb.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public string? Password { get; set; }

        public string? Msg { get; set; }

        private readonly ILogger<LoginModel> _logger;

        public LoginModel(ILogger<LoginModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Email != null && Password != null)
                if (LoginController.LoginUser(Email, Password))
                    return RedirectToPage("Index",
                        new { isLogged = true, email = Email });
            Msg = "B³êdne dane logowania";
            return Page();
        }
    }
}
