using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Model;
using bolnica.Model.Dto;
using Repository;

namespace bolnica.Repository
{
    public class PatientNotificationRepository : IPatientNotificationRepository
    {
        private readonly IPatientRepository _patientRepository;
        private readonly MyDbContext myDbContext;

        public PatientNotificationRepository(IPatientRepository patientRepository, MyDbContext context)
        {
            _patientRepository = patientRepository;
            myDbContext = context;
        }

        public void Delete(PatientNotification entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(PatientNotification entity)
        {
            throw new NotImplementedException();
        }

        public PatientNotification Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientNotification> GetEager()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientNotification> GetAllEager()
        {
            List<PatientNotification> patientNotifications = new List<PatientNotification>();
            foreach (PatientNotification notification in GetEager().ToList())
            {
                patientNotifications.Add(GetEager(notification.GetId()));
            }
            return patientNotifications;
        }

        public PatientNotification GetEager(long id)
        {
            PatientNotification patientNotification = Get(id);
            patientNotification.Patient = _patientRepository.GetEager(patientNotification.Patient.GetId());

            return patientNotification;
        }

        public PatientNotification Save(PatientNotification entity)
        {
            throw new NotImplementedException();
        }
    }
}
