using ErpWeb.Controllers;
using ErpWeb.Services;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public LoginModel(ILogger<LoginModel> logger, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            if (Email != null && Password != null)
                if (LoginController.LoginUser(Email, Password))
                {
                    _logger.LogInformation("User logged in.");
                    _userService.SetLoginUserName(Email);
                    return RedirectToPage("Index");
                }
            Msg = "B³êdne dane logowania";
            return Page();
        }
    }
}
