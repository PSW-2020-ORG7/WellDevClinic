using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Web_app.Models
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
        TERM
    }

    public class NewExaminationTimeSpent : DomainEvent
    {
        public int PatientId { get; set; }

        public StepIds StepId { get;  set; }

        public StepTypes StepType { get;  set; }

        public long ScheduleId { get; set; }

        public NewExaminationTimeSpent() { }

        /*public NewExaminationTimeSpent(int patientId, int stepId, String stepType)
        {
            this.PatientId = patientId;
            switch (stepId)
            {
                case 0:
                    this.StepName = "Date selection";
                    break;
                case 1:
                    this.StepName = "Speciality selection";
                    break;
                case 2:
                    this.StepName = "Doctor selection";
                    break;
                case 3:
                    this.StepName = "Term selection";
                    break;
            }
            if (stepType.Equals(StepTypes.BACK.ToString()))
            {
                this.StepType = StepTypes.BACK;
            }
            if (stepType.Equals(StepTypes.NEXT.ToString()))
            {
                this.StepType = StepTypes.NEXT;
            }
        }*/
    }
}
