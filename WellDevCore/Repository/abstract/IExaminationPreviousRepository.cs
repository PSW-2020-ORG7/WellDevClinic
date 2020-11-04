using bolnica.Repository;
using Model.PatientSecretary;
using Model.Users;
using System.Collections.Generic;

namespace Repository
{
    public interface IExaminationPreviousRepository : IRepository<Examination,long>, IEagerRepository<Examination, long>
   { 
      List<Examination> GetExaminationsByUser(User user);
   }
}