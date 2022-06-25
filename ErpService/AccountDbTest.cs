namespace ErpService
{
    public class AccountDbTest : AccountDb, IAccountDb
    {
        private AccountDbTest() 
        {
            _accounts = new List<Account>();
        }

        public static IAccountDb GetDb() => new AccountDbTest();

        protected override List<Account> GetAccounts() => _accounts;

        protected override bool SaveAccountsData(List<Account> accounts)
        {
            _accounts = accounts;
            return true;
        }

        private List<Account> _accounts;
    }
}
