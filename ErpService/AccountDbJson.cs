using System.Text.Json;

namespace ErpService
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
            if(!File.Exists(FilePath))
                return new List<Account>();
            var data = File.ReadAllText(FilePath);
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
            Directory.CreateDirectory(DirectoryPath);
            File.WriteAllText(FilePath, json);
            return true;
        }

        private static string DirectoryPath
        {
            get
            {
                var dir = Environment.CurrentDirectory;
                var folder = @"LocalDb\";
                return Path.Combine(dir, folder);
            }
        }

        private static string FilePath
        {
            get
            {
                string fileName = "JsonAccountsData.txt";
                return Path.Combine(DirectoryPath, fileName);
            }
        }
    }
}
