using System;
using PSW_Pharmacy_Adapter.Dto;

namespace PSW_Pharmacy_Adapter.Converter
{
    public static class DateTimeConverter
    {
        public static ActionAndBenefitDtoConverted DtoToModel(ActionAndBenefitDto actionAndBenefitDto)
            => new ActionAndBenefitDtoConverted(actionAndBenefitDto.Id,
                                                    actionAndBenefitDto.PharmacyName,
                                                    actionAndBenefitDto.MessageAboutAction,
                                                    DateTimeOffset.FromUnixTimeMilliseconds(actionAndBenefitDto.StartDate).DateTime,
                                                    DateTimeOffset.FromUnixTimeMilliseconds(actionAndBenefitDto.EndDate).DateTime);
    }
}
