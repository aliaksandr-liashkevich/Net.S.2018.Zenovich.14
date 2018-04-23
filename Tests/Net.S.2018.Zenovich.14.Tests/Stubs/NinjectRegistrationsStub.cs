using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._14.BLL.Infrastructure.Api;
using Net.S._2018.Zenovich._14.BLL.Infrastructure.Bonuses;
using Net.S._2018.Zenovich._14.BLL.Infrastructure.Features;
using Net.S._2018.Zenovich._14.BLL.Services.Interfaces;
using Net.S._2018.Zenovich._14.DAL.Contexts;
using Net.S._2018.Zenovich._14.DAL.Repositories;
using Net.S._2018.Zenovich._14.DAL.Repositories.Interfaces;
using Ninject.Modules;

namespace Net.S._2018.Zenovich._14.Tests.Stubs
{
    class NinjectRegistrationsStub : NinjectModule
    {
        public override void Load()
        {
            Bind<ApplicationDbContext>().To<ApplicationDbContext>().InSingletonScope();

            //Bind<IPeopleRepository>().To<PeopleRepository>();
            //Bind<IAccountRepository>().To<AccountRepository>();

            Bind<IAccountService>().To<BLL.Services.AccountService>();
            Bind<IPeopleService>().To<BLL.Services.PeopleService>();

            Bind<IBonusCounter>().To<BonusCounter>();
            Bind<IAccountTypeFeatures>().To<AccountTypeFeatures>();

            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
