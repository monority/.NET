namespace _ExerciceAccount.Classes;

public abstract class BankAccount
{
    private string _client;
    private decimal _balance;
    private List<Operations> _operations;
    public BankAccount(string client, decimal balance, List<Operations> operations)
    {
        _client = client;
        _balance = balance;
        _operations = operations;
    }
}