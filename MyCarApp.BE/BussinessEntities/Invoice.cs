using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{

    public class Invoice
    {

        public System.Guid InvoiceId { get; set; }
        public string TranscationId { get; set; }
        public int Frequency { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedAt { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }



        public virtual ICollection<CarPurchase> CarPurchases { get; set; }
       

        public virtual ICollection<CarRent> CarRents { get; set; }
    }
}
