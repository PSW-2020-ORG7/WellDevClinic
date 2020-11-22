using bolnica;
using bolnica.Model;
using bolnica.Repository;
using Model.Director;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class RoomTypeRepository : CSVRepository<RoomType, long>, IRoomTypeRepository
    {
        private readonly MyDbContext myDbContext;

        /*public RoomTypeRepository()
        {
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }*/

        public RoomTypeRepository(ICSVStream<RoomType> stream, ISequencer<long> sequencer)
    : base(stream, sequencer)
        {
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }

        public void Delete(RoomType entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(RoomType entity)
        {
            throw new NotImplementedException();
        }

        public RoomType Get(long id)
            => myDbContext.RoomType.FirstOrDefault(roomType => roomType.Id == id);


        public IEnumerable<RoomType> GetAll()
        {
            List<RoomType> result = new List<RoomType>();
            myDbContext.RoomType.ToList().ForEach(roomType => result.Add(roomType));
            return result;
        }

        public IEnumerable<RoomType> GetAllEager()
        {
            return GetAll();
        }

        public RoomType GetEager(long id)
        {
            return Get(id);
        }

        public RoomType Save(RoomType entity)
        {
            throw new NotImplementedException();
        }
    }
}
