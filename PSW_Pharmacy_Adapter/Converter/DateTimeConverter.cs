using System;
using Newtonsoft.Json;
using PSW_Pharmacy_Adapter.Dto;

namespace PSW_Pharmacy_Adapter.Converter
{
    public class DateTimeConverter
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime FromUnixTime(long unixTime)
           => epoch.AddSeconds(unixTime);

        public static ActionAndBenefitDtoConverted DtoToModel(ActionAndBenefitDto actionAndBenefitDto)
            => new ActionAndBenefitDtoConverted(actionAndBenefitDto.Id,
                                                    actionAndBenefitDto.PharmacyName,
                                                    actionAndBenefitDto.MessageAboutAction,
                                                    DateTimeOffset.FromUnixTimeMilliseconds(actionAndBenefitDto.StartDate).DateTime,
                                                    DateTimeOffset.FromUnixTimeMilliseconds(actionAndBenefitDto.EndDate).DateTime);
    }
}
