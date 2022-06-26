namespace ErpWeb.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetLoginUserName(string name)
        {
            _httpContextAccessor?.HttpContext?.Session.SetString("Email", name);
        }

        public string GetLoginUserName()
        {
            var username = _httpContextAccessor?.HttpContext?.Session.GetString("Email");
            if (username != null)
                return username;
            return "";
        }
    }
}
