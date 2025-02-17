

using Microsoft.EntityFrameworkCore;
namespace Exercice_Api.Data;


public abstract class BaseRepository
{
    protected readonly ApplicationDbContext _context;
    protected BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }
}
