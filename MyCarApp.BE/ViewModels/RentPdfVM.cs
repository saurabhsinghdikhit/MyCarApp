using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.ViewModels
{
    public class RentPdfVM
    {
        public Guid CarRentId { get; set; }
        public string CarName { get; set; }
        public string CarVarientName { get; set; }
        public decimal Price { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
        public string UserAddress { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string  status { get; set; }
    }
}
