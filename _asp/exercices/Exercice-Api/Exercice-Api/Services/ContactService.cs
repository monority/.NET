using Exercice_Api.Models;
using Microsoft.Extensions.Hosting;

namespace Exercice_Api.Services;

public class ContactService : IContactService
{
    private readonly IRepository<Contact> _repository;

    public ContactService(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public HashSet<Contact> GetAll()
    {
        return _repository.GetAll().ToHashSet();
    }

    public Contact? Get(string parameter)
    {
        var contact = _repository.Get(c =>
                                            (c.FirstName != null && c.FirstName.Contains(parameter)) ||
                                           (c.LastName != null && c.LastName.Contains(parameter)) ||
                                           (c.Email != null && c.Email.Contains(parameter)));
        if (contact == null) return null;
        var findContact = _repository.GetById(contact.Id);
        return findContact;
    }



    public Contact? GetById(int id)
    {
        var contact = _repository.GetById(id);
        if (contact == null) return null;
        return contact;
    }
    public Contact? GetByName(string lastName)
    {
        var contact = _repository.GetByName(lastName);
        if (contact == null) return null;
        return contact;
    }
    public Contact Add(Contact entity)
    {
        _repository.Add(entity);
        return entity;
    }

    public Contact? Update(Contact entity)
    {
        var existingContact = _repository.GetById(entity.Id);
        if (existingContact == null) throw new InvalidOperationException("Contact not found.");

        if (existingContact.FirstName != entity.FirstName)
        {
            existingContact.FirstName = entity.FirstName;
        }
        if (existingContact.LastName != entity.LastName)
        {
            existingContact.LastName = entity.LastName;
        }
        if (existingContact.Email != entity.Email)
        {
            existingContact.Email = entity.Email;
        }
        if (existingContact.PhoneNumber != entity.PhoneNumber)
        {
            existingContact.PhoneNumber = entity.PhoneNumber;
        }
        if (existingContact.BirthDate != entity.BirthDate)
        {
            existingContact.BirthDate = entity.BirthDate;
        }
        if (existingContact.Gender != entity.Gender)
        {
            existingContact.Gender = entity.Gender;
        }
        var updatedContact = _repository.Update(existingContact);
        return updatedContact;
    }

    public bool Delete(Contact entity)
    {
        var findContact = _repository.GetById(entity.Id);
        if (findContact == null) throw new InvalidOperationException("Contact not found.");
        return _repository.Delete(entity.Id);
    }
}
