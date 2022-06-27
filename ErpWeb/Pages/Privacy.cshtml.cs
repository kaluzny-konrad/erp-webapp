using ErpWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErpWeb.Pages;

public class PrivacyModel : BasePage
{

    public PrivacyModel(
        ILogger<BasePage> logger,
        IHttpContextAccessor httpContextAccessor,
        IUserService userService)
    : base(logger, httpContextAccessor, userService) { }

    public void OnGet()
    {
    }
}

