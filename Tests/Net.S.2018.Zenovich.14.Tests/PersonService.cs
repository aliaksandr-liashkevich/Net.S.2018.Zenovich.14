using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Net.S._2018.Zenovich._14.BLL.Infrastructure;
using Net.S._2018.Zenovich._14.BLL.Infrastructure.Bonuses;
using Net.S._2018.Zenovich._14.BLL.Infrastructure.Features;
using Net.S._2018.Zenovich._14.BLL.Services;
using Net.S._2018.Zenovich._14.BLL.Services.Interfaces;
using Net.S._2018.Zenovich._14.DAL.Models;
using Net.S._2018.Zenovich._14.DAL.Repositories.Interfaces;
using Net.S._2018.Zenovich._14.Tests.Stubs;

namespace Net.S._2018.Zenovich._14.Tests
{
    [TestClass]
    public class PersonService
    {
        private Client client;

        private IPeopleService service;
        private Mock<IPeopleRepository> mock;
        private Person person;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IPeopleRepository>();

            IPeopleRepository people = mock.Object;

            IAccountRepository account = new AccountRepositoryStub();

            IUnitOfWork unitOfWork = new UnitOfWorkStub(account, people);

            IPeopleService peopleService = new PeopleService(unitOfWork);
            IAccountService accountService = new AccountService(unitOfWork, new BonusCounter(), new AccountTypeFeatures());

            client = new Client(accountService, peopleService, unitOfWork);

            service = client.PeopleService;
        }

        [TestMethod]
        public void Add_MethodAddWasCalledInRepository()
        {
            // arrange
            mock.Setup(r => r.Add(It.IsAny<Person>()));

            // act
            service.Add(new PL.ViewModels.Person.RegisterViewModel()
            {
                FirstName = "Bob",
                LastName = "Frank",
                Email = "bob@gmail.com"
            });

            // assert
            mock.VerifyAll();
        }

        [TestMethod]
        public void GetAll_MethodGetAllWasCalledInRepository()
        {
            // arrange
            mock.Setup(r => r.GetAll());
            service.Add(new PL.ViewModels.Person.RegisterViewModel()
            {
                FirstName = "Bob",
                LastName = "Frank",
                Email = "bob@gmail.com"
            });

            // act
            service.GetAll();

            // assert
            mock.VerifyAll();
        }

    }
}
