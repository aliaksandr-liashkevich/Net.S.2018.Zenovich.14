using Net.S._2018.Zenovich._14.DAL.Models;

namespace Net.S._2018.Zenovich._14.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Net.S._2018.Zenovich._14.DAL.Contexts.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Net.S._2018.Zenovich._14.DAL.Contexts.ApplicationDbContext context)
        {
            if (context.Accounts.Any() == false && context.People.Any() == false)
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
}
