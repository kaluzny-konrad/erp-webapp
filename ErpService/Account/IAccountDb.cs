namespace ErpService.Account
{
    public interface IAccountDb
    {
        bool AddAccount(string username, string password);
        int? GetAccountId(string username);
        public bool DeleteAccount(int id);
        public Account? GetAccount(int id);
        bool IsActive(string username);
        int GetAccountCount();
    }
}
