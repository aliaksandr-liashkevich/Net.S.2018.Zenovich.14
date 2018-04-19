using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Net.S._2018.Zenovich._14.BLL.Configuration;
using Net.S._2018.Zenovich._14.BLL.Infrastructure.Api;
using Net.S._2018.Zenovich._14.BLL.Services.Interfaces;
using Net.S._2018.Zenovich._14.DAL.Models;
using Net.S._2018.Zenovich._14.DAL.Repositories.Interfaces;
using Net.S._2018.Zenovich._14.PL.ViewModels.Account;
using Net.S._2018.Zenovich._14.PL.ViewModels.Person;
using Ninject;

namespace Net.S._2018.Zenovich._14.BLL.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;
        private IPeopleRepository _peopleRepository;

        private IBonusCounter _bonusCounter;
        private IAccountTypeFeatures _accountTypeFeatures;

        public AccountService(IUnitOfWork unitOfWork, IBonusCounter bonusCounter, IAccountTypeFeatures accountTypeFeatures)
        {
            _accountRepository = unitOfWork.AccountRepository;
            _peopleRepository = unitOfWork.PeopleRepository;
            _bonusCounter = bonusCounter;
            _accountTypeFeatures = accountTypeFeatures;
        }

        public void Add(AddedAccountViewModel vm)
        {
            if (vm == null)
            {
                throw new ArgumentNullException(nameof(vm));
            }

            var person = _peopleRepository.Get(vm.OwnerId);

            if (person != null)
            {
                var account = Mapper.Map<AddedAccountViewModel, Account>(vm);
                account.Owner = person;

                _accountRepository.Add(account);
            }
        }

        public IEnumerable<AccountViewModel> GetAll()
        {
            var accounts = Mapper.Map<IEnumerable<Account>, List<AccountViewModel>>(_accountRepository.GetAll());
            return accounts;
        }

        public AccountViewModel Get(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var account = Mapper.Map<Account, AccountViewModel>(_accountRepository.Get(id));
            return account;
        }

        public void Close(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var account = _accountRepository.Get(id);
            if (account != null)
            {
                if (account.IsClosed == false)
                {
                    account.IsClosed = true;
                    _accountRepository.Update(account);
                }
            }
        }

        public void ReOpen(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var account = _accountRepository.Get(id);
            if (account != null)
            {
                if (account.IsClosed)
                {
                    account.IsClosed = false;
                    _accountRepository.Update(account);
                }
            }
        }

        public void AddedAmount(UpdatedAmountViewModel vm)
        {
            if (vm == null)
            {
                throw new ArgumentNullException(nameof(vm));
            }

            if (vm.Currency < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(vm));
            }

            Account account = _accountRepository.Get(vm.Id);
            if (account != null)
            {
                if (account.IsClosed)
                {
                    return;
                }

                _accountTypeFeatures.Load(account.Type);
                account.Bonus = _bonusCounter.GetBonusFromAdded(_accountTypeFeatures, vm.Currency);
                account.Amount = account.Amount + account.Bonus + vm.Currency;

                _accountRepository.Update(account);
            }
        }

        public void WithdrawalAmount(UpdatedAmountViewModel vm)
        {
            if (vm == null)
            {
                throw new ArgumentNullException(nameof(vm));
            }

            if (vm.Currency < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(vm));
            }

            Account account = _accountRepository.Get(vm.Id);
            if (account != null)
            {
                if (account.Amount - vm.Currency < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(vm));
                }

                if (account.IsClosed)
                {
                    return;
                }

                _accountTypeFeatures.Load(account.Type);
                account.Bonus = _bonusCounter.GetBonusFromAdded(_accountTypeFeatures, vm.Currency);
                account.Amount = account.Amount + account.Bonus - vm.Currency;

                _accountRepository.Update(account);
            }
        }
    }
}
