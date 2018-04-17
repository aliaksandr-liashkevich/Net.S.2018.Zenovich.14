using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._14.DAL.Models;

namespace Net.S._2018.Zenovich._14.DAL.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        void Add(Account account);

        IEnumerable<Account> GetAll();

        Account Get(Guid id);

        void Update(Account account);
    }
}
