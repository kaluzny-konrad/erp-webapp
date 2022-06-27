using ErpWeb.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErpWeb.Pages
{
    public abstract class BasePage : PageModel
    {
        protected readonly ILogger<BasePage> _logger;
        protected readonly IUserService _userService;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        protected BasePage(ILogger<BasePage> logger, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public bool IsLogged => _userService.IsLoggedIn();
        protected string? Session => _httpContextAccessor.HttpContext?.Request?.Cookies.FirstOrDefault(e => e.Key == ".AspNetCore.Session").Value;
    }
}
