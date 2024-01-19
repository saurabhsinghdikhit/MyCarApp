using MyCarApp.BE.BussinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.ViewModels
{
    public class CarDetails
    {
        public Guid CarId { get; set; }
        public string LocalAddress { get; set; }
        public System.Guid PincodeId { get; set; }
    }
}
