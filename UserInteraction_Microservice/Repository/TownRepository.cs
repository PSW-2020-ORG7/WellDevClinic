﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserInteraction_Microservice.Domain;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.Repository
{
    public class TownRepository : ITownRepository
    {
        private readonly MyDbContext _myDbContext;

        public TownRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Town entity)
        {
            _myDbContext.Town.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Town entity)
        {
            _myDbContext.Town.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Town Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Town> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Town> GetAllEager()
        {
            return _myDbContext.Town.ToList();
        }

        public Town GetEager(long id)
        {
            return _myDbContext.Town.FirstOrDefault(d => d.Id == id);
        }

        public Town Save(Town entity)
        {
            _myDbContext.Town.Add(entity);
            _myDbContext.SaveChanges();
            return entity;
        }
    }
}