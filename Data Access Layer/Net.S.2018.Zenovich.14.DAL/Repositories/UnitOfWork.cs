using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._14.DAL.Contexts;
using Net.S._2018.Zenovich._14.DAL.Repositories.Interfaces;

namespace Net.S._2018.Zenovich._14.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _applicationDbContext;

        private bool _disposed;

        public UnitOfWork(ApplicationDbContext applicationDbContext,
            IAccountRepository accountRepository,
            IPeopleRepository peopleRepository)
        {
            _applicationDbContext = applicationDbContext;
            AccountRepository = accountRepository;
            PeopleRepository = peopleRepository;
        }

        public IAccountRepository AccountRepository { get; private set; }
        public IPeopleRepository PeopleRepository { get; private set; }

        ~UnitOfWork()
        {
            CleanUp(false);
        }

        public void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        }

        private void CleanUp(bool clean)
        {
            if (!this._disposed)
            {
                if (clean)
                {
                    _applicationDbContext.Dispose();
                }
            }

            this._disposed = true;
        }
    }
}
