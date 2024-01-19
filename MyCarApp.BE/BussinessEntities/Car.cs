using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{
    public class Car
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> ModifyAt { get; set; }
        public Nullable<System.Guid> CreaatedBy { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public System.Guid Id { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.Guid> CarCategoryId { get; set; }
        public string Brand { get; set; }
        public string Image { get; set; }
        public Nullable<System.Guid> AddressId { get; set; }
        public Nullable<decimal> Kilometers { get; set; }

        public virtual Address Address { get; set; }
        public virtual CarCategory CarCategory { get; set; }
        public virtual ICollection<CarCategoryMapper> CarCategoryMappers { get; set; }
        public virtual ICollection<CarVarient> CarVarients { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
