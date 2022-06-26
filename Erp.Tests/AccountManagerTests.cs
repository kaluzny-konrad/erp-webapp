using ErpService.Account;

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
    public void UsingAccountManager_LoginToNewAccount()
    {
        // Arrange
        var accountDb = AccountDbTest.GetDb();
        var accountManager = AccountManager.GetManager(accountDb);

        var expName = "user@test.pl";
        var expPassword = "password";
        accountManager.NewAccount(expName, expPassword);

        // Act
        var isLogged = accountManager.LoginToAccount(expName, expPassword);

        // Assert
        Assert.True(isLogged);
    }

    [Fact]
    public void UsingAccountManager_DontCreateAccountDuplicate()
    {
        // Arrange
        var accountDb = AccountDbTest.GetDb();
        var accountManager = AccountManager.GetManager(accountDb);

        var name = "Test";
        var acResultNew = accountManager.NewAccount(name, "test1");

        // Act
        var acResultDuplicate = accountManager.NewAccount(name, "test2");

        // Assert
        Assert.Equal(1, accountManager.NumOfAccounts);
        Assert.True(acResultNew);
        Assert.False(acResultDuplicate);
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