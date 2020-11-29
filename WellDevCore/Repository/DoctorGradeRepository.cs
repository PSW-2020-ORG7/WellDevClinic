using bolnica;
using bolnica.Model;
using bolnica.Repository;
using Model.Doctor;
using PSW_Web_app.Adapters;
using PSW_Web_app.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository
{
   public class DoctorGradeRepository : IDoctorGradeRepository
   {
        private readonly MyDbContext myDbContext;


        public DoctorGradeRepository(MyDbContext context)
        {
            myDbContext = context;
        }


        public void Delete(DoctorGrade entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(DoctorGrade entity)
        {
            throw new NotImplementedException();
        }

        public DoctorGrade Get(long id)
            => myDbContext.DoctorGrade.FirstOrDefault(doctorGrade => doctorGrade.Id == id);

        public IEnumerable<DoctorGrade> GetEager()
        {
            List<DoctorGrade> result = new List<DoctorGrade>();
            myDbContext.DoctorGrade.ToList().ForEach(doctorGrade => result.Add(doctorGrade));
            return result;
        }

        public DoctorGrade Save(DoctorGrade entity)
        { 
            DoctorGrade result = myDbContext.DoctorGrade.FirstOrDefault(doctorGrade => doctorGrade.Id == entity.Id);
            if (result == null)
            {
                myDbContext.DoctorGrade.Add(entity);
                myDbContext.SaveChanges();
                return entity;
            }

            return null;
        }

    }
}