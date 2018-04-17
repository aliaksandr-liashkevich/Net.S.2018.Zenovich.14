using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._14.DAL.Models;

namespace Net.S._2018.Zenovich._14.DAL.Contexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Person> People { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}
