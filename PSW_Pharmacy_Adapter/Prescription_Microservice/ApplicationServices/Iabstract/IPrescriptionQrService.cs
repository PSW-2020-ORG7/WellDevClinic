using PSW_Pharmacy_Adapter.Prescription_Microservice.Domain.Model;

namespace PSW_Pharmacy_Adapter.Prescription_Microservice.ApplicationServices.Iabstract
{
    public interface IPrescriptionQrService
    {
        public byte[] Generate(Prescription prescription);
    }
}
