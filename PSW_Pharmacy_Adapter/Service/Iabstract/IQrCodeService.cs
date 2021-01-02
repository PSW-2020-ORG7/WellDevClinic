using PSW_Pharmacy_Adapter.Model;
using System;

namespace PSW_Pharmacy_Adapter.Service.Iabstract
{
    public interface IQrCodeService
    {
        public byte[] Generate(Prescription prescription);
    }
}
