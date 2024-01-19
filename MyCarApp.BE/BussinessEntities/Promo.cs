using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{

    public class Promo
    {
        public Promo()
        {
            this.CarPurchases = new HashSet<CarPurchase>();
        }

        public System.Guid PromoId { get; set; }
        public Nullable<System.Guid> UserId { get; set; }
        public string PromoCode { get; set; }
        public string Details { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.Guid CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedAt { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public bool Isdeleted { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<CarPurchase> CarPurchases { get; set; }
        public virtual User User { get; set; }
    }
}
