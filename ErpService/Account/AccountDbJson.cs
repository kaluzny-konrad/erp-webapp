using System.Text.Json;

namespace ErpService.Account
{
    public class AccountDbJson : AccountDb, IAccountDb
    {
        private AccountDbJson() { }
        private static AccountDbJson? _instance;

        public static IAccountDb GetDb()
        {
            if (_instance == null)
                _instance = new AccountDbJson();
            return _instance;
        }

        protected override List<Account> GetAccounts()
        {
            List<Account> accounts;
            var data = DbJsonSaver.GetData(fileName);
            try
            {
                accounts = JsonSerializer.Deserialize(data,
                    typeof(List<Account>)) as List<Account>;
            }
            catch (JsonException)
            {
                accounts = new List<Account>();
            }
            if (accounts == null)
                accounts = new List<Account>();
            return accounts;
        }

        protected override bool SaveAccountsData(List<Account> accounts)
        {
            string json = JsonSerializer.Serialize(accounts);
            DbJsonSaver.SaveData(json, fileName);
            return true;
        }

        private static string fileName = "JsonAccountsData.txt";
    }
}
