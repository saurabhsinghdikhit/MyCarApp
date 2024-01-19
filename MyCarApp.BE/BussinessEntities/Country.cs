using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.BussinessEntities
{

    public class Country
    {
        public Country()
        {
            this.Currencies = new HashSet<Currency>();
            this.States = new HashSet<State>();
        }

        public System.Guid CountryId { get; set; }
        public string CountryName { get; set; }



        public virtual ICollection<Currency> Currencies { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
