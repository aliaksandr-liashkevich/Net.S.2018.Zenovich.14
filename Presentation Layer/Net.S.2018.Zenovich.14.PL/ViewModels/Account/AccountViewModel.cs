using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.S._2018.Zenovich._14.PL.ViewModels.Account
{
    public class AccountViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }

        public decimal Amount { get; set; }

        public long Bonus { get; set; }

        public AccountType Type { get; set; }

        public bool IsClosed { get; set; }
    }
}
