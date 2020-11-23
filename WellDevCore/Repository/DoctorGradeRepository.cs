using bolnica;
using bolnica.Model;
using bolnica.Repository;
using Model.Doctor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository
{
   public class DoctorGradeRepository : IDoctorGradeRepository
   {
        private readonly MyDbContext myDbContext;
        public DoctorGradeRepository()
        {
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
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
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoctorGrade> GetAll()
        {
            throw new NotImplementedException();
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