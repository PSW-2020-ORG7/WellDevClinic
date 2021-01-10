using System;
using System.Collections.Generic;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.ApplicationServices.Abstract
{
    public interface IPatientAppService : ICRUD<Patient, long>, IGetEager<Patient, long>
    {
        public Patient LogIn(String username, String password);
        public Patient ClaimAccount(Patient patient);
        public Patient GetPatientToken(string token);
        public List<Patient> GetBlockedPatients();
        public List<Patient> GetPatientsForBlocking();
        public Patient GetPatientByJMBG(string jmbg);
        public DoctorGrade GradeDoctor(DoctorGrade doctorGrade, Doctor doctor);
        public void Block(long id);
    }
}
