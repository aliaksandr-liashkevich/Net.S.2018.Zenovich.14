using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._14.DAL.Contexts;
using Net.S._2018.Zenovich._14.DAL.Models;
using Net.S._2018.Zenovich._14.DAL.Repositories.Interfaces;

namespace Net.S._2018.Zenovich._14.DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public ApplicationDbContext Db { get; set; }

        public void Add(Account account)
        {
            Db.Accounts.Add(account);
            Db.SaveChanges();
        }

        public IEnumerable<Account> GetAll()
        {
            return Db.Accounts;
        }

        public Account Get(Guid id)
        {
            return Db.Accounts.Find(id);
        }

        public void Update(Account account)
        {
            Db.Entry(account).State = EntityState.Modified;
        }
    }
}
