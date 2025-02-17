using Exercice_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercice_Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Contact> Contacts { get; set; }



}
