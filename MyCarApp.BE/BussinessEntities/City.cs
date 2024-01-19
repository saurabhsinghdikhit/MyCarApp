using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{
    public class City
    {

        public City()
        {
            this.Pincodes = new HashSet<Pincode>();
        }

        public System.Guid CityId { get; set; }
        public System.Guid StateId { get; set; }
        public string CityName { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<Pincode> Pincodes { get; set; }
    }
}
