namespace ErpService.Account
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

        public bool NewAccount(string username, string password)
        {
            if (!_accountDb.IsActive(username))
                return _accountDb.AddAccount(username, password);
            return false;
        }

        public bool LoginToAccount(string email, string password)
        {
            var id = _accountDb.GetAccountId(email);
            if (id != null)
            {
                var account = _accountDb.GetAccount((int)id);
                if (account != null)
                    return account.Password == password;
            }
            return false;
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
