using Exercice_Api.Models;

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
        return _repository.GetAll().Select(MapToViewModel).ToHashSet();
    }

    public Contact? GetById(int id)
    {
        var contact = _repository.GetById(id);
        if (contact == null) return null;
        return MapToViewModel(contact);
    }
    public Contact? GetByName(string lastName)
    {
        var contact = _repository.GetByName(lastName);
        if (contact == null) return null;
        return MapToViewModel(contact);
    }
    public Contact Add(Contact entity)
    {
        var contact = MapToEntity(entity);
        return MapToViewModel(_repository.Add(contact));
    }


    public Contact? Update(Contact entity)
    {
        var contact = MapToEntity(entity);  
        var updatedContact = _repository.Update(contact);
        if (updatedContact == null) throw new InvalidOperationException("Contact not found.");
        return MapToViewModel(updatedContact);
    }

    public bool Delete(Contact entity)
    {
        var findContact = _repository.GetById(entity.Id);
        if (findContact == null) throw new InvalidOperationException("Contact not found.");
        return _repository.Delete(entity.Id);
    }

    private Contact MapToViewModel(Contact contact)
    {
        return new Contact()
        {
            Id = contact.Id,
            Age = DateTime.Now.Year - contact.BirthDate.Year,
            FullName = $"{contact.LastName} {contact.FirstName}",
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            Email = contact.Email,
            PhoneNumber = contact.PhoneNumber,
            BirthDate = contact.BirthDate,
            Gender = contact.Gender,
        };
    }

    private Contact MapToEntity(Contact contact)
    {
        return new Contact()
        {
            Id = contact.Id,
            Age = DateTime.Now.Year - contact.BirthDate.Year,
            FullName = $"{contact.LastName} {contact.FirstName}",
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            Email = contact.Email,
            PhoneNumber = contact.PhoneNumber,
            BirthDate = contact.BirthDate,
            Gender = contact.Gender,
        };
    }
}
