namespace ErpService.Account;
public class Account
{
    public Account(int id, string name, string password)
    {
        Id = id;
        Name = name;
        Password = password;
    }

    public int Id { get; }
    public string Name { get; }
    public string Password { get; }
}
