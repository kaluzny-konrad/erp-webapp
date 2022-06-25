using ErpService;

namespace Erp.Tests;

public class AccountManagerTests
{
    [Fact]
    public void UsingAccountManager_NewAccount()
    {
        // Arrange
        var accountDb = AccountDbTest.GetDb();
        var accountManager = AccountManager.GetManager(accountDb);

        var expName = "user@test.pl";
        var expPassword = "password";
        accountManager.NewAccount(expName, expPassword);

        // Act
        var account = accountManager.GetAccount(expName);

        // Assert
        Assert.NotNull(account);
        if (account is not null)
        {
            Assert.Equal(expName, account.Name);
            Assert.Equal(expPassword, account.Password);
        }
    }

    [Fact]
    public void UsingAccountManager_DontCreateAccountDuplicate()
    {
        // Arrange
        var accountDb = AccountDbTest.GetDb();
        var accountManager = AccountManager.GetManager(accountDb);

        var name = "Test";
        accountManager.NewAccount(name, "test1");

        // Act
        accountManager.NewAccount(name, "test2");

        // Assert
        Assert.Equal(1, accountManager.NumOfAccounts);
    }

    [Fact]
    public void UsingAccountManager_ToDeleteAccount()
    {
        // Arrange
        var accountDb = AccountDbTest.GetDb();
        var accountManager = AccountManager.GetManager(accountDb);

        accountManager.NewAccount("user@test.pl", "password");
        var account = accountManager.GetAccount("user@test.pl");
        Assert.NotNull(account);

        // Act
        if (account is not null)
            accountManager.DeleteAccount(account.Id);

        // Assert
        Assert.Equal(0, accountManager.NumOfAccounts);
    }
}