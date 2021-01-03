using bolnica.Repository;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System.Collections.Generic;


namespace bolnica.Repository
{
   public interface IExaminationUpcomingRepository : IRepository<Examination, long>, IEagerRepository<Examination, long>
   {
      List<Examination> GetUpcomingExaminationsByUser(User user);
        Examination Save(long doctorId, Period period, long patientId);
        List<Examination> GetAllUpcomingExaminations();
    }
}