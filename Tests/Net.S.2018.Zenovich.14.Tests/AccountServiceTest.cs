using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Net.S._2018.Zenovich._14.BLL.Infrastructure;
using Net.S._2018.Zenovich._14.BLL.Infrastructure.Bonuses;
using Net.S._2018.Zenovich._14.BLL.Infrastructure.Features;
using Net.S._2018.Zenovich._14.BLL.Services;
using Net.S._2018.Zenovich._14.BLL.Services.Interfaces;
using Net.S._2018.Zenovich._14.DAL.Models;
using Net.S._2018.Zenovich._14.DAL.Repositories;
using Net.S._2018.Zenovich._14.DAL.Repositories.Interfaces;
using Net.S._2018.Zenovich._14.PL.ViewModels.Account;
using Net.S._2018.Zenovich._14.Tests.Stubs;
using Ninject;
using AccountType = Net.S._2018.Zenovich._14.PL.ViewModels.Account.AccountType;

namespace Net.S._2018.Zenovich._14.Tests
{
    [TestClass]
    public class AccountServiceTest
    {
        private Client client;

        private IAccountService service;
        private Mock<IAccountRepository> mock;
        private Person person;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IAccountRepository>();

            person = new Person()
            {
                FirstName = "Alex",
                LastName = "Zenovich",
                Email = "alex@email.com"
            };

            IPeopleRepository people = new PeopleRepositoryStub();
            people.Add(person);

            IAccountRepository account = mock.Object;

            IUnitOfWork unitOfWork = new UnitOfWorkStub(account, people);

            IPeopleService peopleService = new PeopleService(unitOfWork);
            IAccountService accountService = new AccountService(unitOfWork, new BonusCounter(), new AccountTypeFeatures());

            client = new Client(accountService, peopleService, unitOfWork);

            service = client.AccountService;
        }

        [TestMethod]
        public void Add_MethodAddWasCalledInRepository()
        {
            // arrange
            mock.Setup(r => r.Add(It.IsAny<Account>()));

            // act
            service.Add(new PL.ViewModels.Account.AddedAccountViewModel()
            {
                OwnerId = person.Id,
                Type = AccountType.Base
            });

            // assert
            mock.VerifyAll();
        }

        [TestMethod]
        public void Get_MethodGetWasCalledInRepository()
        {
            // arrange
            mock.Setup(r => r.Get(It.IsAny<Guid>()));

            // act
            service.Get(person.Id);

            // assert
            mock.VerifyAll();
        }

        [TestMethod]
        public void GetAll_MethodGetAllWasCalledInRepository()
        {
            // arrange
            mock.Setup(r => r.GetAll());

            // act
            service.GetAll();

            // assert
            mock.VerifyAll();
        }
    }
}
