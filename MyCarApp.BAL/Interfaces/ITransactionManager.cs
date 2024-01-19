using MyCarApp.BE.BussinessEntities;
using MyCarApp.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BAL.Interfaces
{
    public interface ITransactionManager
    {
        Guid CarPurchase(string local,int pincode,string TransactionId, CarPurchase carPurchase);
        CarVarient ConfirmPurchase(Guid CarVarientId);
        Guid CarRent(string local, int pincode, string TransactionId, CarRent carRent);
        PdfVM GeneratePDF(Guid purchaseId);
        RentPdfVM GenerateRentPDF(Guid RentId);
    }
}
