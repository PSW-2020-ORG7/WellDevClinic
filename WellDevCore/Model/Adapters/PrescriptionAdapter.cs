using Model.PatientSecretary;
//using PSW_Web_app.dtos;
using bolnica.Model.dtos;
using WellDevCore.Model.dtos;

namespace bolnica.Model.Adapters
{
    public class PrescriptionAdapter
    {
        public static PrescriptionDto PrescriptionToPrescriptionDto(Prescription prescription)
        {
            PrescriptionDto dto = new PrescriptionDto
            {
                Period = prescription.Period.StartDate.ToShortDateString(),
                Id = prescription.Id
            };
            string str = "";
            foreach (Drug drug in prescription.Drug) {
                str += (drug.Name + ",");
            }
            dto.Drugs = str;
            return dto;
        }

        public static PatientPrescriptionDTO ExaminationToPatientPrescriptionDto(Examination examination)
            => new PatientPrescriptionDTO()
            {
                Id = examination.Prescription.Id,
                TimePeriod = examination.Prescription.Period,
                Drugs = examination.Prescription.Drug,
                PatJmbg = examination.Patient.Jmbg,
                PatFirstName = examination.Patient.FirstName,
                PatLastName = examination.Patient.LastName,
            };
    }
}
