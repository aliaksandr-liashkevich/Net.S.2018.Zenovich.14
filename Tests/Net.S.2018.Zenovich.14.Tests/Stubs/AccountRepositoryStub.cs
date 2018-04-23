using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._14.DAL.Models;
using Net.S._2018.Zenovich._14.DAL.Repositories.Interfaces;

namespace Net.S._2018.Zenovich._14.Tests.Stubs
{
    class AccountRepositoryStub : IAccountRepository
    {
        private List<Account> accounts = new List<Account>();

        public void Add(Account account)
        {
            if (account.Owner.Accounts == null)
            {
                account.Owner.Accounts = new List<Account>();
            }

            account.Owner.Accounts.Add(account);

            accounts.Add(account);
        }

        public IEnumerable<Account> GetAll()
        {
            return accounts;
        }

        public Account Get(Guid id)
        {
            return accounts.FirstOrDefault((a) => a.Id.Equals(id));
        }

        public void Update(Account account)
        {
        }
    }
}
