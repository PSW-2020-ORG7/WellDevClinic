using System;

namespace PSW_Pharmacy_Adapter.Service.Iabstract
{
    public interface IQrCodeService
    {
        public Byte[] Generate(string qrText);
    }
}
