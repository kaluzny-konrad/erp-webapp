using ErpWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErpWeb.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public string? Email { get; set; }
    public string? Session { get; set; }

    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserService _userService;

    public IndexModel(ILogger<IndexModel> logger, IHttpContextAccessor httpContextAccessor, IUserService userService)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
        _userService = userService;
    }

    public void OnGet()
    {
        Email = _userService.GetLoginUserName();
        Session = _httpContextAccessor.HttpContext?.Request?.Cookies.FirstOrDefault(e => e.Key == ".AspNetCore.Session").Value;
    }
}
