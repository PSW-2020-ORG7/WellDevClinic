using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Model;
using bolnica.Repository.CSV;
using Model.Users;
using Repository;

namespace bolnica.Repository
{
    public class StateRepository : CSVGetterRepository<State, long>, IStateRepository 
    {
        private readonly ITownRepository _townRepository;
        private readonly MyDbContext myDbContext;

        /*public StateRepository(ITownRepository townRepository)
        {
            _townRepository = townRepository;
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }*/

        public StateRepository(ICSVStream<State> stream, ISequencer<long> sequencer, ITownRepository townRepository) : base(stream, sequencer)
        {
            _townRepository = townRepository;
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }

        public State Get(long id)
            => myDbContext.State.FirstOrDefault(state => state.Id == id);

        public IEnumerable<State> GetAll()
        {
            List<State> result = new List<State>();
            myDbContext.State.ToList().ForEach(state => result.Add(state));
            return result;
        }

        public IEnumerable<State> GetAllEager()
        {
            List<State> states = GetAll().ToList();
            for (int i = 0; i < states.Count; i++)
                states[i] = GetEager(states[i].GetId());
            return states;
        }

        public State GetEager(long id)
        {
            State state = this.Get(id);
            List<Town> towns = state.GetTown();
            for(int i = 0; i < towns.Count; i++)
            {
                towns[i] = _townRepository.GetEager(towns[i].GetId());
            }
            return state;
        }
    }
}
