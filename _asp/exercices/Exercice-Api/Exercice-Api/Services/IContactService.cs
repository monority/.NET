
using Exercice_Api.Models;

namespace Exercice_Api.Services;

public interface IContactService
{
    public HashSet<Contact> GetAll();
    public Contact? GetById(int id);
    public Contact? Get(string parameter);
    public Contact? GetByName(string lastName);
    public Contact Add(Contact entity);
    public Contact? Update(Contact entity);
    public bool Delete(Contact entity);
}