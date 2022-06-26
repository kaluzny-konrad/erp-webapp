using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErpWeb.Pages
{
    public class RegisterConfirmationModel : PageModel
    {
        public string? Email { get; private set; }

        public void OnGet(string email)
        {
            Email = email;
        }
    }
}
