using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._14.BLL.Configuration;
using Net.S._2018.Zenovich._14.BLL.Infrastructure.Configuration;
using Net.S._2018.Zenovich._14.BLL.Services.Interfaces;
using Net.S._2018.Zenovich._14.DAL.Repositories.Interfaces;
using Ninject;

namespace Net.S._2018.Zenovich._14.BLL.Infrastructure
{
    public class Client : IDisposable
    {
        private IAccountService _accountService;
        private IPeopleService _peopleService;
        private IUnitOfWork _unitOfWork;

        private bool _disposed;

        public Client()
        {
            Extensions.AddMapper();
            IKernel kernel = new StandardKernel(new NinjectRegistrations());
            _unitOfWork = kernel.Get<IUnitOfWork>();
            _accountService = kernel.Get<IAccountService>();
            _peopleService = kernel.Get<IPeopleService>();
        }

        public Client(IKernel kernel)
        {
            Extensions.AddMapper();
            _unitOfWork = kernel.Get<IUnitOfWork>();
            _accountService = kernel.Get<IAccountService>();
            _peopleService = kernel.Get<IPeopleService>();
        }

        public Client(IAccountService accountService,
            IPeopleService peopleService,
            IUnitOfWork unitOfWork)
        {
            Extensions.AddMapper();
            _unitOfWork = unitOfWork;
            _peopleService = peopleService;
            _accountService = accountService;
        }

        public IAccountService AccountService
        {
            get { return _accountService; }
        }

        public IPeopleService PeopleService
        {
            get { return _peopleService; }
        }

        ~Client()
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
                    _unitOfWork.Dispose();
                }
            }

            this._disposed = true;
        }
    }
}
