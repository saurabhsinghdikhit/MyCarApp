using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{

    public class User
    {

        public User()
        {
            this.CarPurchases = new HashSet<CarPurchase>();
            this.CarRents = new HashSet<CarRent>();
            this.Promoes = new HashSet<Promo>();
            this.Reviews = new HashSet<Review>();
        }

        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] HashPassword { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public Nullable<System.Guid> AddressId { get; set; }
        public string IdProof { get; set; }
        public int Points { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedAt { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool Status { get; set; }

        public string Image { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<CarPurchase> CarPurchases { get; set; }

        public virtual ICollection<CarRent> CarRents { get; set; }

        public virtual ICollection<Promo> Promoes { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
 