using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{

    public class Currency
    {
        public Currency()
        {
            this.CarPurchases = new HashSet<CarPurchase>();
        }

        public System.Guid CurrencyId { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> CountryId { get; set; }

        public virtual ICollection<CarPurchase> CarPurchases { get; set; }
        public virtual ICollection<CarRent> CarRents { get; set; }
        public virtual Country Country { get; set; }
    }
}
