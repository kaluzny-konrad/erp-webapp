using ErpWeb.Services;

namespace ErpWeb.Pages;

public class IndexModel : BasePage
{
    public IndexModel(
        ILogger<BasePage> logger,
        IHttpContextAccessor httpContextAccessor, 
        IUserService userService) 
    : base(logger, httpContextAccessor, userService) { }

    public void OnGet()
    {
        
    }
}
