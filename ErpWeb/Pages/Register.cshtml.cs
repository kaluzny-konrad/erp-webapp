using ErpWeb.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErpWeb.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public string? Password { get; set; }
        public string? Msg { get; private set; }

        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(ILogger<RegisterModel> logger)
        {
            _logger = logger;
        }

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
            Msg = "B³êdne dane logowania lub konto o takim e-mailu ju¿ istnieje.";
            return Page();
        }
    }
}
