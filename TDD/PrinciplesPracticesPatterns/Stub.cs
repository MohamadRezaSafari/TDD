namespace PrinciplesPracticesPatterns;

public class Stub
{
    [Fact]
    public async void GetTransactions_populates_Transactions_property()
    {
        //Arrange
        var transactionViewModel = new TransactionViewModel(new StubWalletController());

        //Act
        await transactionViewModel.GetTransactions();

        //Assert
        Assert.Equal(3, transactionViewModel.Transactions.Count);
    }
}



public class TransactionViewModel
{
    //1
    private IWalletController _walletController;

    //2
    public TransactionViewModel(IWalletController walletController)
    {
        _walletController = walletController;
        Transactions = new List<Transaction>();
    }

    public List<Transaction> Transactions
    {
        get;
        set;
    }

    //3
    public async Task GetTransactions()
    {
        var transactions = await _walletController.GetTransactions();
        Transactions = transactions;
    }
}


public interface IWalletController
{
    Task<List<Transaction>> GetTransactions(bool forceReload = false);
    Task<List<Coin>> GetCoins(bool forceReload = false);
}


class StubWalletController : IWalletController
{
    public Task<List<Coin>> GetCoins(bool forceReload = false)
    {
        throw new NotImplementedException();
    }

    //2
    public Task<List<Transaction>> GetTransactions(bool forceReload = false)
    {
        var task = Task.FromResult(new List<Transaction>
        {
            new Transaction { Id = 1, Amount = 2, Symbol = "BTC" },
            new Transaction { Id = 2, Amount = 3, Symbol = "ETH" },
            new Transaction { Id = 3, Amount = 7, Symbol = "ETH" },
        });
        return task;
    }
}


public class Coin
{
}

public class Transaction
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Symbol { get; set; }
}