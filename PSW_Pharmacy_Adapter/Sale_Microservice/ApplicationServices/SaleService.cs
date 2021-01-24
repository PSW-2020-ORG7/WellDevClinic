using System;
using System.Collections.Generic;
using PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Sale_Microservice.Repository.Iabstract;

namespace PSW_Pharmacy_Adapter.Sale_Microservice.ApplicationServices
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public Sale GetBenefit(long id) =>
            _saleRepository.Get(id);

        public IEnumerable<Sale> GetAll() =>
            _saleRepository.GetAll();

        public bool DeleteBenefit(long id) =>
            _saleRepository.Delete(id);

        public Sale UpdateStatus(long id, int status) 
        {
            Sale sale = _saleRepository.Get(id);
            switch (status)
            {
                case 0:
                    sale.Status = SaleStatus.pending;
                    break;
                case 1:
                    sale.Status = SaleStatus.accepted;
                    break;
                case 2:
                    sale.Status = SaleStatus.favourite;
                    break;
            }
            return _saleRepository.Update(sale);
        }

        public void DeleteExpiredAction()
        {
            foreach (Sale sale in GetAll())
            {
                if (sale.ValPeriod.EndDate < DateTime.Now)
                {
                    _saleRepository.Delete((long)sale.Id);
                }
            }
        }

    }
}
