using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing
{
    public enum StepTypes
    {
        NEXT,
        BACK
    }

    public enum StepIds
    {
        DATE,
        SPECIALITY,
        DOCTOR,
        TERM,
        SUCCESS
    }

    public class NewExaminationTimeSpent : DomainEvent
    {
        public int PatientId { get; set; }

        public StepIds StepId { get; set; }

        public StepTypes StepType { get; set; }

        public long ScheduleId { get; set; }

        public NewExaminationTimeSpent() { }

        public NewExaminationTimeSpent(int patientId, StepIds stepId, StepTypes stepType, long scheduleId)
        {
            PatientId = patientId;
            StepId = stepId;
            StepType = stepType;
            ScheduleId = scheduleId;
        }
    }
}
