namespace ErpService
{
    public abstract class AccountDb
    {
        protected abstract List<Account> GetAccounts();
        protected abstract bool SaveAccountsData(List<Account> accounts);

        public bool AddAccount(string username, string password)
        {
            var accounts = GetAccounts();
            Account account = new(NextIndex, username, password);
            accounts.Add(account);
            return SaveAccountsData(accounts);
        }

        public bool DeleteAccount(int id)
        {
            var accounts = GetAccounts();
            accounts.RemoveAt(id);
            return SaveAccountsData(accounts);
        }

        public Account? GetAccount(int id)
        {
            var accounts = GetAccounts();
            var account = GetAccounts().FirstOrDefault(u => u.Id == id);
            if (account == null)
                return null;
            return account;
        }

        public int GetAccountCount()
        {
            return GetAccounts().Count;
        }

        public int? GetAccountId(string username)
        {
            var account = GetAccounts().FirstOrDefault(u => u.Name == username);
            if (account == null)
                return null;
            return account.Id;
        }

        public bool IsActive(string username)
        {
            var account = GetAccounts().FirstOrDefault(u => u.Name == username);
            if (account == null)
                return false;
            return true;
        }

        protected int NextIndex
        {
            get
            {
                var accounts = GetAccounts();
                return accounts.Any() ? accounts.Last().Id + 1 : 0;
            }
        }
    }
}
