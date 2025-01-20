namespace _ExerciceAccount.Classes;

public class Client
{
    private string _firstName { get; set; }
    private string _lastName { get; set; }
    private int _phoneNumber;
    private string _username { get; }
    private int _accountList { get; }

    public Client(string firstName, string lastName, int phoneNumber, string username, int accountList)
    {
        _firstName = firstName;
        _lastName = lastName;
        _phoneNumber = phoneNumber;
        _username = username;
        _accountList = accountList;
    }
    
}