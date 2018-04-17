using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._14.DAL.Models;

namespace Net.S._2018.Zenovich._14.DAL.Contexts.Configuration
{
    public class ApplicationInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            Person alex = new Person()
            {
                FirstName = "Alex",
                LastName = "Zenovich",
                Email = "alex@example.com",
            };

            Person bob = new Person()
            {
                FirstName = "Bob",
                LastName = "Frank",
                Email = "bob@example.com"
            };

            Account alexBaseAccount = new Account()
            {
                Type = AccountType.Base,
                Ownder = alex
            };

            Account alexGoldAccount = new Account()
            {
                Type = AccountType.Gold,
                Ownder = alex,
            };

            Account bobAccount = new Account()
            {
                Type = AccountType.Platinum,
                Ownder = bob
            };

            context.Accounts.Add(alexBaseAccount);
            context.Accounts.Add(alexGoldAccount);
            context.Accounts.Add(bobAccount);

            context.SaveChanges();
        }
    }
}
