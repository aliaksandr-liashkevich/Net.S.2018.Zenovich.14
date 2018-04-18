using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._14.PL.ViewModels.Account;
using Net.S._2018.Zenovich._14.PL.ViewModels.Person;

namespace Net.S._2018.Zenovich._14.BLL.Services.Interfaces
{
    public interface IPersonService 
    {
        void Add(RegisterViewModel vm);

        IEnumerable<PersonViewModel> GetAll();

        PersonViewModel Get(Guid id);

        IEnumerable<AccountViewModel> GetClientAccounts(Guid id);
    }
}
