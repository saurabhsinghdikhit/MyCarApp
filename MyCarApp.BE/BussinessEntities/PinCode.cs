using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{

    public class Pincode
    {
        public Pincode()
        {
            this.Addresses = new HashSet<Address>();
        }

        public System.Guid PincodeId { get; set; }
        public System.Guid CityId { get; set; }
        public int Pincode1 { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual City City { get; set; }
    }
}
