using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.ViewModels
{
    public class PdfVM
    {
        public Guid CarPurchaseId { get; set; }
        public string CarName { get; set; }
        public string CarVarientName { get; set; }
        public decimal Price { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string DealerName { get; set; }
        public string Image { get; set; }
        public string DealerAddress { get; set; }
        public string DealerContact { get; set; }
        public DateTime Date { get; set; }
        public string status { get; set; }
    }
}
