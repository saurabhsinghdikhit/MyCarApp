using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{

    public class State
    {

        public State()
        {
            this.Cities = new HashSet<City>();
        }

        public System.Guid StateId { get; set; }
        public System.Guid CountryId { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual Country Country { get; set; }
    }
}
