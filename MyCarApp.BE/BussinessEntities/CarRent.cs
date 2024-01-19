using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{
    public class CarRent
    {
        public System.Guid CarRentId { get; set; }
        public System.Guid CarVarientId { get; set; }
        public System.Guid UserId { get; set; }
        public System.Guid CurrencyId { get; set; }
        public System.DateTime BookingDate { get; set; }
        public System.Guid PickupPoint { get; set; }
        public System.DateTime ReturningDate { get; set; }
        public System.Guid DropPoint { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaymentDone { get; set; }
        public System.Guid PaymentMethodId { get; set; }
        public System.Guid InvoiceId { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.Guid CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedAt { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool Status { get; set; }

        public virtual Address Address { get; set; }
        public virtual Address Address1 { get; set; }
        public virtual CarVarient CarVarient { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual User User { get; set; }
    }
}
