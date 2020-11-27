using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class ExaminationDbDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long DoctorId { get; set; }
        public long PeriodId { get; set; }
        public long DiagnosisId { get; set; }
        public long PrescriptionId { get; set; }
        public long AnemnesisId { get; set; }
        public long TherapyId { get; set; }
        public long RefferalId { get; set; }
        public long PatientFileId { get; set; }
        public long RoomOccuoationreportDTOId { get; set; }
        public long RoomOccuoationreportDTOId1 { get; set; }
        public long SecretaryReportDTOId { get; set; }

        public ExaminationDbDto()
        {
        }

    }
}
