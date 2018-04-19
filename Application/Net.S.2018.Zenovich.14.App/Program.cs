using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._14.BLL.Infrastructure;
using Net.S._2018.Zenovich._14.BLL.Services;
using Net.S._2018.Zenovich._14.BLL.Services.Interfaces;
using Net.S._2018.Zenovich._14.PL.ViewModels.Account;
using Net.S._2018.Zenovich._14.PL.ViewModels.Person;

namespace Net.S._2018.Zenovich._14.App
{
    class Program 
    {
        static void Main(string[] args)
        {

            Client client = new Client();
            IPersonService personService = client.PersonService;
            IAccountService accountService = client.AccountService;



            

            var t = personService.Get("tom.x@gmail.com");

            if (t != null)
            {
                Console.WriteLine(t.Id);
                Console.WriteLine(t.FirstName + " " + t.LastName);
                Console.WriteLine(t.Email);
                Console.WriteLine("---");
            }

            var tomAccount =  personService.GetClientAccounts(t.Id).First();

            accountService.WithdrawalAmount(new UpdatedAmountViewModel()
            {
                Currency = 100,
                Id = tomAccount.Id
            });

            var acc = accountService.Get(tomAccount.Id);

            Console.WriteLine(acc.Amount);


            

            client.Dispose();

            Console.ReadKey();
        }
    }
}
