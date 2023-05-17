using ContactData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ContactData.Datacontext
{
    public class ContactManagerDbContext : DbContext
    {

        public ContactManagerDbContext() : base() { }

        private static DbContextOptions GetOptions(string connectionString) => SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;

        public ContactManagerDbContext(string connectionString) : base(GetOptions(connectionString)) { }


        public ContactManagerDbContext(DbContextOptions<ContactManagerDbContext> dbContextOptions) : base(dbContextOptions) { }



        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {




        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(QuickSeed.thecontacts);

            modelBuilder.Entity<Address>().HasData(QuickSeed.thecaddress);


            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Address)
               .WithMany(e => e.Contacts)
                .HasForeignKey(e => e.AddressId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
