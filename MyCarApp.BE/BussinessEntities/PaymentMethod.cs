using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{

    public class PaymentMethod
    {
        public PaymentMethod()
        {
            this.CarPurchases = new HashSet<CarPurchase>();
            this.CarRents = new HashSet<CarRent>();
        }

        public System.Guid PaymentMethodId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CarPurchase> CarPurchases { get; set; }
        public virtual ICollection<CarRent> CarRents { get; set; }
    }
}
