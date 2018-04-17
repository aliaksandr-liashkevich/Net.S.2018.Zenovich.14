using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._14.DAL.Contexts;
using Net.S._2018.Zenovich._14.DAL.Models;
using Net.S._2018.Zenovich._14.DAL.Repositories.Interfaces;

namespace Net.S._2018.Zenovich._14.DAL.Repositories
{
    public class PeopleRepository :IPeopleRepository
    {
        public ApplicationDbContext Db { get; set; }

        public void Add(Person person)
        {
            Db.People.Add(person);
        }

        public IEnumerable<Person> GetAll()
        {
            return Db.People;
        }

        public Person Get(Guid id)
        {
            return Db.People.Find(id);
        }
    }
}
