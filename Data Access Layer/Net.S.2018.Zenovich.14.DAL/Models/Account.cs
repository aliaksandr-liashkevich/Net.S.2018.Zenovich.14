using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.S._2018.Zenovich._14.DAL.Models
{
    public class Account
    {
        private decimal amount;

        private long bonus;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        public DateTime CreationDate { get; }

        [DefaultValue(0)]
        [Required]
        public decimal Amount {
            get
            {
                return amount;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Amount));
                }

                if (amount - value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Amount));
                }

                amount = value;
            }
        }

        [DefaultValue(0)]
        [Required]
        public long Bonus {
            get { return bonus; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Bonus));
                }

                bonus = value;
            }
        }
        
        [Required]
        public AccountType Type { get; set; }

        [DefaultValue(false)]
        [Required]
        public bool IsClosed { get; set; }

        [Required]
        public Person Owner { get; set; }
    }
}
