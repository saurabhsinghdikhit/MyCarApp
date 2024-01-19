using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{
    public class CarCategory
    {
        public string Category { get; set; }
        public System.Guid Id { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime ModifyAt { get; set; }
        public System.Guid CreaatedBy { get; set; }
        public System.Guid ModifiedBy { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<CarCategoryMapper> CarCategoryMappers { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
