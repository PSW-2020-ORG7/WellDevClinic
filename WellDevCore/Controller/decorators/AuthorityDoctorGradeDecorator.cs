﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Model.Dto;
using Model.Doctor;
using Model.Users;

namespace bolnica.Controller.decorators
{
    public class AuthorityDoctorGradeDecorator : IDoctorGradeController
    {
        private IDoctorGradeController DoctorGradeController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;
        public AuthorityDoctorGradeDecorator(IDoctorGradeController doctorGradeController, string role)
        {
            DoctorGradeController = doctorGradeController;
            Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["Delete"] = new List<String>() { "Patient" };
            AuthorizedUsers["Edit"] = new List<String>() { "Patient" };
            AuthorizedUsers["Get"] = new List<String>() { "Patient" };
            AuthorizedUsers["GetAll"] = new List<String>() { "Patient" };
            AuthorizedUsers["Save"] = new List<String>() { "Patient" };
            AuthorizedUsers["GetAverageGrade"] = new List<String>() { "Patient" };
        }

        public void Delete(DoctorGrade entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(x => x == Role) != null)
                DoctorGradeController.Delete(entity);
        }

        public void Edit(DoctorGrade entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(x => x == Role) != null)
                DoctorGradeController.Edit(entity);
        }

        public DoctorGrade Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return DoctorGradeController.Get(id);
            else
                return null;
        }

        public IEnumerable<DoctorGrade> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return DoctorGradeController.GetAll();
            else
                return null;
        }

        public List<GradeDTO> GetAverageGrade(DoctorGrade doctor)
        {
            if (AuthorizedUsers["GetAverageGrade"].SingleOrDefault(x => x == Role) != null)
                return DoctorGradeController.GetAverageGrade(doctor);
            else
                return null;
        }

        public List<GradeDTO> GetAverageGradeDoctor(List<DoctorGrade> surveys)
        {
            if (AuthorizedUsers["GetAverageGradeDoctor"].SingleOrDefault(x => x == Role) != null)
                return DoctorGradeController.GetAverageGradeDoctor(surveys);
            else
                return null;
        }

        public List<DoctorGrade> GetByDoctor(string doctor)
        {
            if (AuthorizedUsers["GetByDoctor"].SingleOrDefault(x => x == Role) != null)
                return DoctorGradeController.GetByDoctor(doctor);
            else
                return null;
        }

        public DoctorGrade Save(DoctorGrade entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(x => x == Role) != null)
                return DoctorGradeController.Save(entity);
            else
                return null;
        }
    }
}
