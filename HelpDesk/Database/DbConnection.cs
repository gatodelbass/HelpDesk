using HelpDesk.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Database
{
    public class DbConnection: DbContext
    {
        public DbConnection(DbContextOptions<DbConnection> options) : base(options)
        {
            
        }


        public DbSet<Ticket> Tickets { get; set; }


    }
}
