using PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Dto;
using PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Converter;

namespace PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Model
{
    public static class ActionAndBenefitMapper
    {
        public static ActionAndBenefit MapActionAndBenefit(ActionAndBenefitDto actionDto, ActionStatus status)
            => new ActionAndBenefit
            {
                Id = actionDto.Id,
                PharmacyName = actionDto.PharmacyName,
                MessageAboutAction = actionDto.MessageAboutAction,
                StartDate = DateTimeConverter.UnixToDateTime(actionDto.StartDate),
                EndDate = DateTimeConverter.UnixToDateTime(actionDto.EndDate),
                Status = status
            };
    }
}
