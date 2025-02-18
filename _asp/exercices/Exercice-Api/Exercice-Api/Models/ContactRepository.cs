using Exercice_Api.Data;
using Exercice_Api.Models;


public class ContactRepository : BaseRepository, IRepository<Contact>
{
    public ContactRepository(ApplicationDbContext context) : base(context)
    {
    }

    public Contact Create(Contact entity)
    {
        _context.Contacts.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public Contact Add(Contact entity)
    {
        _context.Contacts.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public bool Delete(int id)
    {
        var contactFound = _context.Contacts.FirstOrDefault(c => c.Id == id);
        if (contactFound == null) return false;
        _context.Contacts.Remove(contactFound);
        _context.SaveChanges();
        return true;
    }
    public IEnumerable<Contact> GetAll(Func<Contact, bool> predicate)
    {
        return _context.Contacts.Where(predicate);
    }

    public IEnumerable<Contact> GetAll()
    {
        var Contacts = _context.Contacts.ToHashSet();
        return Contacts;
    }

    public Contact? GetById(int id)
    {
        var contactFound = _context.Contacts.FirstOrDefault(c => c.Id == id);
        var contactFoundSingle = _context.Contacts.SingleOrDefault(c => c.Id == id);
        return contactFound;
    }

    public Contact? GetByName(string lastName)
    {
        var contactFound = _context.Contacts.FirstOrDefault(c => c.LastName == lastName);
        var contactFoundSingle = _context.Contacts.SingleOrDefault(c => c.LastName == lastName);
        return contactFound;
    }

    public Contact? Update(Contact entity)
    {
        var contactFound = _context.Contacts.FirstOrDefault(c => c.Id == entity.Id);
        _context.SaveChanges();
        return contactFound;
    }
    public Contact? FilterBy(Contact entity){
        var contactFound = _context.Contacts.FirstOrDefault(c => c.Id == entity.Id);
        return contactFound;

    }
}
