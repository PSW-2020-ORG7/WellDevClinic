using System;
using PSW_Pharmacy_Adapter.Dto;

namespace PSW_Pharmacy_Adapter.Converter
{
    public static class DateTimeConverter
    {
        public static DateTime UnixToDateTime(long epoha)
            => DateTimeOffset.FromUnixTimeMilliseconds(epoha).DateTime;
    }
}
