using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{

    public class Address
    {
        public Address()
        {
            this.CarPurchases = new HashSet<CarPurchase>();
            this.CarRents = new HashSet<CarRent>();
            this.CarRents1 = new HashSet<CarRent>();
            this.Dealers = new HashSet<Dealer>();
            this.Users = new HashSet<User>();
            this.Cars = new HashSet<Car>();
        }

        public System.Guid AddressId { get; set; }
        public string LocalAddress { get; set; }
        public System.Guid PincodeId { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedAt { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool Status { get; set; }

        public virtual Pincode Pincode { get; set; }

        public virtual ICollection<CarPurchase> CarPurchases { get; set; }

        public virtual ICollection<CarRent> CarRents { get; set; }
        public virtual ICollection<CarRent> CarRents1 { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Dealer> Dealers { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
