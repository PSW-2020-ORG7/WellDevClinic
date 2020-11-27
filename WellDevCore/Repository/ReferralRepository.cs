using bolnica;
using bolnica.Model;
using bolnica.Repository;
using bolnica.Service;
using Model.Doctor;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ReferralRepository : IReferralRepository
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly MyDbContext myDbContext;

        public ReferralRepository(IDoctorRepository doctorRepository, MyDbContext context)
        {
            _doctorRepository = doctorRepository;
            myDbContext = context;
        }

        /*public ReferralRepository(ICSVStream<Model.Doctor.Referral> stream, ISequencer<long> sequencer, IDoctorRepository doctorRepository)
  : base(stream, sequencer)
        {
            _doctorRepository = doctorRepository;
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }*/

        public void Delete(Referral entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Referral entity)
        {
            throw new NotImplementedException();
        }

        public Referral Get(long id)
            => myDbContext.Referral.FirstOrDefault(referral => referral.Id == id);

        public IEnumerable<Referral> GetEager()
        {
            List<Referral> result = new List<Referral>();
            myDbContext.Referral.ToList().ForEach(referral => result.Add(referral));
            return result;
        }

        public IEnumerable<Referral> GetAllEager()
        {
            List<Referral> referral = new List<Referral>();
            foreach(Referral r in GetEager().ToList()){
                referral.Add(GetEager(r.GetId()));
            }
            return referral;
        }

        public Referral GetEager(long id)
        {
            Referral referral = Get(id);
            referral.Doctor = _doctorRepository.GetEager(referral.Doctor.GetId());
            return referral;
        }

        public Referral Save(Referral entity)
        {
            throw new NotImplementedException();
        }
    }
}
