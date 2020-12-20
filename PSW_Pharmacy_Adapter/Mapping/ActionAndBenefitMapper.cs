using PSW_Pharmacy_Adapter.Dto;
using PSW_Pharmacy_Adapter.Converter;

namespace PSW_Pharmacy_Adapter.Model
{
    public class ActionAndBenefitMapper
    {
        public static ActionAndBenefit mapActionAndBenefit(ActionAndBenefitDto actionDto, ActionStatus status)
        {
            ActionAndBenefit actionAndBenefit = new ActionAndBenefit();
            actionAndBenefit.Id = actionDto.Id;
            actionAndBenefit.PharmacyName = actionDto.PharmacyName;
            actionAndBenefit.MessageAboutAction = actionDto.MessageAboutAction;
            actionAndBenefit.StartDate = DateTimeConverter.UnixToDateTime(actionDto.StartDate);
            actionAndBenefit.EndDate = DateTimeConverter.UnixToDateTime(actionDto.EndDate);
            actionAndBenefit.Status = status;

            return actionAndBenefit;
        }
    }
}
