using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.CB
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Підключення до бази даних
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ContactBookDB;Trusted_Connection=True;");
        }
    }
}
