namespace ErpService
{
    public class AccountManager
    {
        private AccountManager(IAccountDb accountDb) 
        {
            _accountDb = accountDb;
        }

        private static AccountManager? _instance;

        public static AccountManager GetManager(IAccountDb accountDb)
        {
            if (_instance == null)
                _instance = new AccountManager(accountDb);
            return _instance;
        }

        public int NumOfAccounts => _accountDb.GetAccountCount();

        public void NewAccount(string username, string password)
        {
            if (!_accountDb.IsActive(username))
                _accountDb.AddAccount(username, password);
        }

        public Account? GetAccount(string username)
        {
            var id = _accountDb.GetAccountId(username);
            if (id == null)
                return null;
            else
                return _accountDb.GetAccount((int)id);
        }

        public void DeleteAccount(int id) => _accountDb.DeleteAccount(id);

        public static void DeleteInstance() => _instance = null;

        private readonly IAccountDb _accountDb;
    }
}
