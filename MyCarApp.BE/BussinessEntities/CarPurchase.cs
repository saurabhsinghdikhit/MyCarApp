using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{
    public class CarPurchase
    {
        public System.Guid CarPurchaseId { get; set; }
        public System.Guid UserId { get; set; }
        public System.Guid DealerId { get; set; }
        public System.Guid CarVarientId { get; set; }
        public System.Guid InvoiceId { get; set; }
        public System.Guid PaymentMethodId { get; set; }
        public Nullable<System.Guid> PromoId { get; set; }
        public Nullable<System.Guid> EmiId { get; set; }
        public bool IsFullPayment { get; set; }
        public System.Guid CurrencyId { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; }
        public Nullable<System.Guid> AddressId { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedAt { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Address Address { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Dealer Dealer { get; set; }
        public virtual EMI EMI { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual Promo Promo { get; set; }
        public virtual User User { get; set; }
    }
}


