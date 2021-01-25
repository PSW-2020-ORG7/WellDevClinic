using PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Dto;
using PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Converter;

namespace PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Model
{
    public static class SaleMapper
    {
        public static Sale MapSale(SaleDto saleDto, SaleStatus status)
            => new Sale
            {
                Id = saleDto.Id,
                PharmacyName = saleDto.PharmacyName,
                SaleMessage = saleDto.SaleMessage,
                ValPeriod = new Period(DateTimeConverter.UnixToDateTime(saleDto.StartDate),
                                       DateTimeConverter.UnixToDateTime(saleDto.EndDate)),
                Status = status
            };
    }
}
