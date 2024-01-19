using MyCarApp.BAL.Interfaces;
using MyCarApp.BE.BussinessEntities;
using MyCarApp.BE.ViewModels;
using MyCarApp.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BAL.Classes
{
    public class TransactionManager : ITransactionManager
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionManager(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public Guid CarPurchase(string local, int pincode, string TransactionId, CarPurchase carPurchase)
        {
            return _transactionRepository.CarPurchase(local,pincode, TransactionId, carPurchase);
        }

        public CarVarient ConfirmPurchase(Guid CarVarientId)
        {
            return _transactionRepository.ConfirmPurchase(CarVarientId);
        }
        public Guid CarRent(string local, int pincode, string TransactionId, CarRent carRent)
        {
            return _transactionRepository.CarRent(local, pincode, TransactionId, carRent);
        }

        public PdfVM GeneratePDF(Guid purchaseId)
        {
            return _transactionRepository.GeneratePDF(purchaseId);
        }

        public RentPdfVM GenerateRentPDF(Guid RentId)
        {
            return _transactionRepository.GenerateRentPDF(RentId);
        }
    }
}
