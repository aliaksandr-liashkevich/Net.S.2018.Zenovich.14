using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._14.BLL.Infrastructure;
using Net.S._2018.Zenovich._14.BLL.Services;
using Net.S._2018.Zenovich._14.BLL.Services.Interfaces;

namespace Net.S._2018.Zenovich._14.App
{
    class Program 
    {
        static void Main(string[] args)
        {

            Client client = new Client();
            IPersonService people = client.PersonService;

            var q = people.GetAll();

            foreach (var person in q)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName);
                Console.WriteLine(person.Email);
                Console.WriteLine("---");
            }

            var qA = client.AccountService.GetAll();

            foreach (var account in qA)
            {
                Console.WriteLine(account.Amount);
            }

            Console.ReadKey();
        }
    }
}
