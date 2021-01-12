using System;

namespace PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Converter
{
    public static class DateTimeConverter
    {
        public static DateTime UnixToDateTime(long epoha)
            => DateTimeOffset.FromUnixTimeMilliseconds(epoha).DateTime;
    }
}
