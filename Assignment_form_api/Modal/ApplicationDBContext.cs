using Microsoft.EntityFrameworkCore;
using Assignment_models;
using System.Data;

namespace Assignment_form_api.Modal
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
    
        public DbSet<Registration> registrations { get; set; }

        public DbSet<City> Citys { get; set; } 
        
         public DbSet<Alldetail> details { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
 
            modelBuilder.Entity<City>().ToTable("Country_Table");
           
            modelBuilder.Entity<Registration>().ToTable("Register_Table");

            modelBuilder.Entity<Alldetail>().HasNoKey();



        }

    }
}
