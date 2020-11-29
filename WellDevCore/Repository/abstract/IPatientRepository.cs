

using bolnica.Repository;
using Model.Users;
using Repository;
using System;

namespace bolnica.Repository
{
   public interface IPatientRepository : IRepository<Patient, long>, IUserGetterRepository, IEagerRepository<Patient, long>
    {
      Patient GetPatientByJMBG(String jmbg);

      Patient GetPatientByMail(String email);

      Patient GetPatientByUsername(String username);

      Patient GetPatientToken(string token);
    }
}