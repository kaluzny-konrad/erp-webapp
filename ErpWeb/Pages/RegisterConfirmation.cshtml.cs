using ErpWeb.Services;

namespace ErpWeb.Pages;

public class RegisterConfirmationModel : BasePage
{
    public string? Email { get; private set; }

    public RegisterConfirmationModel(
        ILogger<BasePage> logger,
        IHttpContextAccessor httpContextAccessor,
        IUserService userService)
    : base(logger, httpContextAccessor, userService) { }

    public void OnGet(string email)
    {
        Email = email;
    }
}
