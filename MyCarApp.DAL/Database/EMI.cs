//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyCarApp.DAL.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class EMI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMI()
        {
            this.CarPurchases = new HashSet<CarPurchas>();
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarPurchas> CarPurchases { get; set; }
    }
}
