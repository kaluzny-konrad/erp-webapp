using ErpService;

namespace Erp.Tests;

public class AccoundDbJsonTests
{
    [Fact]
    public void AccountDbJson_CanAddAccountToFile()
    {
        // Arrange
        var db = AccountDbJson.GetDb();
        var expName = RandomString(10);
        var expPassword = RandomString(10);

        // Act
        db.AddAccount(expName, expPassword);

        // Assert
        var accountId = db.GetAccountId(expName);
        Assert.NotNull(accountId);
        var account = db.GetAccount((int)accountId);
        Assert.NotNull(account);
        Assert.Equal(expName, account.Name);
        Assert.Equal(expPassword, account.Password);
    }

    [Fact]
    public void AccountDbJson_CanDeleteAccountFromFile()
    {
        // Arrange
        var db = AccountDbJson.GetDb();
        var expName = RandomString(10);
        var expPassword = RandomString(10);
        db.AddAccount(expName, expPassword);
        var accountId = db.GetAccountId(expName);
        Assert.NotNull(accountId);

        // Act
        db.DeleteAccount((int)accountId);

        // Assert
        var account = db.GetAccountId(expName);
        Assert.Null(account);
    }

    private static Random random = new Random();
    private static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
