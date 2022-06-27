namespace ErpWeb.Services
{
    public interface IUserService
    {
        void SetEmail(string name);
        string? GetEmail();
        bool IsLoggedIn();
    }

    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor) => _httpContextAccessor = httpContextAccessor;

        void IUserService.SetEmail(string name) => _httpContextAccessor?.HttpContext?.Session.SetString("Email", name);

        public string? GetEmail() => _httpContextAccessor?.HttpContext?.Session.GetString("Email");

        public bool IsLoggedIn()
        {
            var userEmail = GetEmail();
            return userEmail != null && userEmail != "";
        }
    }
}
