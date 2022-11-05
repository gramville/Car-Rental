using System;
using Microsoft.EntityFrameworkCore;


namespace CarRental.Models
{
    
    
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
        {
        }



        public DbSet<car> cars { get; set; }
        public DbSet<customer> customers { get; set; }
        public DbSet<employee> employees { get; set; }
        public DbSet<rent> rents { get; set; }

    }
}
