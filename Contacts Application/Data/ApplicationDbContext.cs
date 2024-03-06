using Contacts_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts_Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Contacts> Contacts
        { get; set; }
    }
}