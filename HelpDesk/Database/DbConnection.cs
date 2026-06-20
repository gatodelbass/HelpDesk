using HelpDesk.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Database
{
    public class DbConnection: IdentityDbContext
    {
        public DbConnection(DbContextOptions<DbConnection> options) : base(options)
        {
            
        }


        public DbSet<Ticket> Tickets { get; set; }


    }
}
