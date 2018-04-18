using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._14.DAL.Models;
using Net.S._2018.Zenovich._14.PL.ViewModels.Account;
using Net.S._2018.Zenovich._14.PL.ViewModels.Person;

namespace Net.S._2018.Zenovich._14.BLL.Services.Interfaces
{
    public interface IAccountService
    {
        void Add(AddedAccountViewModel vm);

        IEnumerable<AccountViewModel> GetAll();

        AccountViewModel Get(Guid id);

        void Close(Guid id);

        void ReOpen(Guid id);

        void AddedAmount(UpdatedAmountViewModel vm);

        void WithdrawalAmount(UpdatedAmountViewModel vm);
    }
}
