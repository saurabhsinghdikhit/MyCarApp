using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{

    public class EMI
    {
        public EMI()
        {
            this.CarPurchases = new HashSet<CarPurchase>();
        }

        public System.Guid EmiId { get; set; }
        public System.Guid BankId { get; set; }
        public string CardType { get; set; }
        public int Period { get; set; }
        public decimal Interest { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.Guid CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedAt { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public bool Isdeleted { get; set; }
        public bool Status { get; set; }

        public virtual Bank Bank { get; set; }
        public virtual ICollection<CarPurchase> CarPurchases { get; set; }
    }
}
