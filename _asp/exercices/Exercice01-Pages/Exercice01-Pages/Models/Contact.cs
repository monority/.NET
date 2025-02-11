namespace Exercice01_Pages.Models;

public class Contact
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }

public Contact(int id, string firstname, string lastname, string email)
    {
        Firstname = firstname;
        Lastname = lastname;
        Email = email;
        Id = id;
    }
}