namespace ErpWeb.Services
{
    public interface IUserService
    {
        void SetLoginUserName(string name);
        string GetLoginUserName();
    }
}
