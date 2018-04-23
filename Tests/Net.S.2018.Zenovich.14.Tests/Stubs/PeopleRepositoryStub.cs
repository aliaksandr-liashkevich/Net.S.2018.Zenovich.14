using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._14.DAL.Models;
using Net.S._2018.Zenovich._14.DAL.Repositories.Interfaces;

namespace Net.S._2018.Zenovich._14.Tests.Stubs
{
    class PeopleRepositoryStub : IPeopleRepository
    {
        private List<Person> people = new List<Person>();

        public void Add(Person person)
        {
            people.Add(person);
        }

        public IEnumerable<Person> GetAll()
        {
            return people;
        }

        public Person Get(Guid id)
        {
            return people.FirstOrDefault((p) => p.Id.Equals(id));
        }
    }
}
