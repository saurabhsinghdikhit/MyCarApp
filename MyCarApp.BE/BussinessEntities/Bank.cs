using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{

    public class Bank
    {
        public Bank()
        {
            this.EMIs = new HashSet<EMI>();
        }

        public System.Guid BankId { get; set; }
        public string BankName { get; set; }

        public virtual ICollection<EMI> EMIs { get; set; }
    }
}
