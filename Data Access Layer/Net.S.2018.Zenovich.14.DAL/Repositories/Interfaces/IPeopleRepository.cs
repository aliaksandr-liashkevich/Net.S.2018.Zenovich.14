using Net.S._2018.Zenovich._14.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.S._2018.Zenovich._14.DAL.Repositories.Interfaces
{
    public interface IPeopleRepository
    {
        void Add(Person person);

        IEnumerable<Person> GetAll();

        Person Get(Guid id);
    }
}
