using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._14.BLL.Infrastructure.Api;

namespace Net.S._2018.Zenovich._14.BLL.Infrastructure.Bonuses
{
    class BonusCounter : IBonusCounter
    {
        public long GetBonusFromRefill(IAccountTypeFeatures accountTypeFeatures, decimal amount)
        {
            return (long)(amount * 0.1m / accountTypeFeatures.AddedPrice);
        }

        public long GetBonusFromAdded(IAccountTypeFeatures accountTypeFeatures, decimal amount)
        {
            return (long)(amount * 0.1m / accountTypeFeatures.WithdrawalPrice);
        }
    }
}
