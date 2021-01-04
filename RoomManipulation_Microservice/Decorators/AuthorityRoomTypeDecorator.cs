using RoomManipulation_Microservice.ApplicationServices.Abstract;
using RoomManipulation_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomManipulation_Microservice.Decorators
{
    public class AuthorityRoomTypeDecorator : IRoomTypeAppService
    {
        private readonly IRoomTypeAppService _roomTypeAppService;
        public String Role { get; set; }
        private readonly Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityRoomTypeDecorator(IRoomTypeAppService roomTypeAppService)
        {
            _roomTypeAppService = roomTypeAppService;
            AuthorizedUsers = new Dictionary<string, List<string>>
            {
                ["Delete"] = new List<string>() { "Director" },
                ["Edit"] = new List<string>() { "Director" },
                ["Get"] = new List<string>() { "Director" },
                ["GetAll"] = new List<string>() { "Director" },
                ["Save"] = new List<string>() { "Director" }
            };
        }

        public void Delete(RoomType entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                _roomTypeAppService.Delete(entity);
        }

        public void Edit(RoomType entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                _roomTypeAppService.Edit(entity);
        }

        public RoomType Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _roomTypeAppService.Get(id);
            return null;
        }

        public IEnumerable<RoomType> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _roomTypeAppService.GetAll();
            return null;
        }

        public RoomType Save(RoomType entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _roomTypeAppService.Save(entity);
            return null;
        }
    }
}
