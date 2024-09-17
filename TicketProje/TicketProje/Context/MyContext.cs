using Microsoft.EntityFrameworkCore;
using TicketProje.Models.Entities;

namespace TicketProje.Context
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-QM2DAN4\\SQLEXPRESS;" +
                "database=TicketDatabase;" +
                "Trusted_connection=true;" +
                "TrustServerCertificate=True");
        }
        public DbSet<UserEntity> users { get; set; }
        public DbSet<TikcetEntity> ticketss { get; set; }
        public DbSet<CategoryEntity> categories { get; set; }
        public DbSet<TicketHistoyEntity> tickethistory { get; set; }
    }
}
