using MyCarApp.BE.BussinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BE.ViewModels
{
    public class CarPurchaseModel
    {
        public int PincodeData { get; set; }
        public string LocalAddress { get; set; }
        public string TransactionId { get; set; }
        public CarPurchase CarPurchase { get; set; }
    }
}
