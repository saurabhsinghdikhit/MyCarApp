using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{
    public class CarVarient
    {
        public System.Guid Id { get; set; }
        public System.Guid carId { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime ModifiedAt { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarPurchase> CarPurchases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarRent> CarRents { get; set; }
        public virtual Car Car { get; set; }
    }
}
