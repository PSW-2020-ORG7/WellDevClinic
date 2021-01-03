using RoomManipulation_Microservice.ApplicationServices.Abstract;
using RoomManipulation_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomManipulation_Microservice.Decorators
{
    public class AuthorityRenovationDecorator : IRenovationAppService
    {
        private readonly IRenovationAppService _renovationAppService;
        public String Role { get; set; }
        private readonly Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityRenovationDecorator(IRenovationAppService renovationAppService)
        {
            _renovationAppService = renovationAppService;
            AuthorizedUsers = new Dictionary<string, List<string>>
            {
                ["Delete"] = new List<string>() { "Director" },
                ["Edit"] = new List<string>() { "Director" },
                ["Get"] = new List<string>() { "Director" },
                ["GetAll"] = new List<string>() { "Director" },
                ["Save"] = new List<string>() { "Director" },
                ["GetRenovationsByRoomAndPeriod"] = new List<string>() { "Director" },
                ["DeleteRenovationByRoom"] = new List<string>() { "Director" }
            };
        }

        public void Delete(Renovation entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                _renovationAppService.Delete(entity);
        }

        public void Edit(Renovation entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                _renovationAppService.Edit(entity);
        }

        public Renovation Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _renovationAppService.Get(id);
            return null;
        }

        public IEnumerable<Renovation> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _renovationAppService.GetAll();
            return null;
        }

        public Renovation Save(Renovation entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _renovationAppService.Save(entity);
            return null;
        }

        public IEnumerable<Renovation> GetRenovationsByRoomAndPeriod(Room room, Period period)
        {
            if (AuthorizedUsers["GetRenovationsByRoomAndPeriod"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _renovationAppService.GetRenovationsByRoomAndPeriod(room, period);
            return null;
        }

        public void DeleteRenovationByRoom(Room room)
        {
            if (AuthorizedUsers["DeleteRenovationByRoom"].SingleOrDefault(any => any.Equals(Role)) != null)
                _renovationAppService.DeleteRenovationByRoom(room);
        }
    }
}
