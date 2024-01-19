using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{

    public class Dealer
    {


        public System.Guid DealerId { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> AddressId { get; set; }
        public string ContactNo { get; set; }
        public bool IsVerified { get; set; }
        public Nullable<System.Guid> VerifiedBy { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedAt { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool Status { get; set; }

        public virtual Address Address { get; set; }
        public virtual Admin Admin { get; set; }
        public virtual ICollection<CarPurchase> CarPurchases { get; set; }
    }
}
