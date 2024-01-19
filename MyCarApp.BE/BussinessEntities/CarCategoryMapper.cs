using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{
    public class CarCategoryMapper
    {
        public System.Guid Id { get; set; }
        public System.Guid CarId { get; set; }
        public System.Guid CarCategoryId { get; set; }

        public virtual CarCategory CarCategory { get; set; }
        public virtual Car Car { get; set; }
    }
}
