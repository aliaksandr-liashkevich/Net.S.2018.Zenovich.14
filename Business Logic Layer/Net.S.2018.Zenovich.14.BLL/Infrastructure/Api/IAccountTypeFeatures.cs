using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._14.DAL.Models;

namespace Net.S._2018.Zenovich._14.BLL.Infrastructure.Api
{
    public interface IAccountTypeFeatures
    {
        decimal WithdrawalPrice { get; }

        decimal AddedPrice { get; }

        void Load(AccountType accountType);
    }
}
