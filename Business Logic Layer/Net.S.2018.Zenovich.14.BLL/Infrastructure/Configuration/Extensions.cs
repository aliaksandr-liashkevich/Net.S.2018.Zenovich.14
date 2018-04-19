using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Net.S._2018.Zenovich._14.DAL.Models;
using Net.S._2018.Zenovich._14.PL.ViewModels.Account;
using Net.S._2018.Zenovich._14.PL.ViewModels.Person;

namespace Net.S._2018.Zenovich._14.BLL.Infrastructure.Configuration
{
    public static class Extensions
    {
        public static void AddMapper()
        {
            Mapper.Initialize((cfg) =>
            {
                cfg.CreateMap<AddedAccountViewModel, Account>();
                cfg.CreateMap<Account, AccountViewModel>();

                cfg.CreateMap<RegisterViewModel, Person>();
                cfg.CreateMap<Person, PersonViewModel>();
            });
        }
    }
}
