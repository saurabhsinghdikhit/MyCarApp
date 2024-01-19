using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{

    public class Review
    {
        public System.Guid ReviewId { get; set; }
        public System.Guid CarId { get; set; }
        public Nullable<System.Guid> UserId { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public string Discription { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public string ModifiedAt { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool Status { get; set; }

        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
    }
}
