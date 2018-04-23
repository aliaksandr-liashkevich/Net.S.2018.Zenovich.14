using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._14.DAL.Repositories.Interfaces;

namespace Net.S._2018.Zenovich._14.Tests.Stubs
{
    class UnitOfWorkStub : IUnitOfWork
    {
        public void Dispose()
        {
        }

        public UnitOfWorkStub(IAccountRepository accountRepository,
            IPeopleRepository peopleRepository)
        {
            AccountRepository = accountRepository;
            PeopleRepository = peopleRepository;
        }

        public IAccountRepository AccountRepository { get; }
        public IPeopleRepository PeopleRepository { get; }
    }
}
