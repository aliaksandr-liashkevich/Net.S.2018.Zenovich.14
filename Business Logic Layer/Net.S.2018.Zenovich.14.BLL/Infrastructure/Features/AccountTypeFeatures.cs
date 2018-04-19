using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._14.BLL.Infrastructure.Api;
using Net.S._2018.Zenovich._14.DAL.Models;

namespace Net.S._2018.Zenovich._14.BLL.Infrastructure.Features
{
    class AccountTypeFeatures : IAccountTypeFeatures
    {
        public decimal WithdrawalPrice { get; protected set; }

        public decimal AddedPrice { get; protected set; }

        public virtual void Load(AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.Base:
                {
                    SetPricesForBase();
                    break;
                }

                case AccountType.Gold:
                {
                    SetPriceForGold();
                    break;
                }

                case AccountType.Platinum:
                {
                    SetPriceForPlatinum();
                    break;
                }

                default:
                {
                    throw new ArgumentException("No such type of bank account.", nameof(accountType));
                }
            }
        }

        protected void SetPricesForBase()
        {
            AddedPrice = 6;
            WithdrawalPrice = 5;
        }

        protected void SetPriceForGold()
        {
            AddedPrice = 5;
            WithdrawalPrice = 4;
        }

        protected void SetPriceForPlatinum()
        {
            AddedPrice = 3;
            WithdrawalPrice = 2;
        }
    }
}
