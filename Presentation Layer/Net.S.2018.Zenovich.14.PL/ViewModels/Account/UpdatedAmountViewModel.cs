using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.S._2018.Zenovich._14.PL.ViewModels.Account
{
    public class UpdatedAmountViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Decimal Currency { get; set; }
    }
}
