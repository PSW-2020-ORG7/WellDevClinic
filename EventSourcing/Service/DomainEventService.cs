﻿using EventSourcing.Events;
using EventSourcing.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventSourcing.Service
{
    public class DomainEventService : IDomainEventService
    {
        private readonly IDomainEventRepository _domainEventRepository;

        public DomainEventService(IDomainEventRepository domainEventRepository)
        {
            _domainEventRepository = domainEventRepository;
        }

        public DomainEvent Save(DomainEvent domainEvent)
        {
            return _domainEventRepository.Save(domainEvent);
        }

        public IEnumerable<DomainEvent> GetAll(string eventType)
        {
            return _domainEventRepository.GetAll(eventType);
        }

        public long GetMax(String eventType)
        {
            return _domainEventRepository.GetMax(eventType);
        }

        public AverageTimeDTO Initialize()
        {
            AverageTimeDTO av = new AverageTimeDTO();
            av.FirstStep = 0;
            av.SecondStep = 0;
            av.ThirdStep = 0;
            av.FourthStep = 0;
            av.FifthStep = 0;
            av.Unsuccessful = 0;
            av.Next = 0;
            av.Prev = 0;
            return av;
        }

        public AverageTimeDTO GetStepTime(String eventType)
        {
            AverageTimeDTO av = Initialize();
            List<DomainEvent> listAll = (List<DomainEvent>)_domainEventRepository.GetAll(eventType);
            List<long> keys = new List<long>();
            foreach(NewExaminationTimeSpent nets in listAll)
            {
                if ((int)nets.StepType == 0)
                {
                    av.Next += 1;
                }
                else
                {
                    av.Prev += 1;
                }
                if (!keys.Contains(nets.ScheduleId))
                {
                    keys.Add(nets.ScheduleId);
                }
            }
            foreach(long key in keys)
            {
                List<NewExaminationTimeSpent> currentSchedule = new List<NewExaminationTimeSpent>();
                foreach(NewExaminationTimeSpent nets in listAll)
                {
                    if (nets.ScheduleId == key )
                    {
                        currentSchedule.Add(nets);
                    }
                }
                currentSchedule.Sort((x, y) => DateTime.Compare(x.TimeStamp, y.TimeStamp));
                for (int i=1; i < currentSchedule.Count; i++)
                {
                    TimeSpan time = currentSchedule[i].TimeStamp - currentSchedule[i - 1].TimeStamp;

                    av = ForLoop(currentSchedule[i - 1], av, time);
                }
            }
            av.FirstStep = Math.Round((av.FirstStep / keys.Count),2);
            av.SecondStep = Math.Round((av.SecondStep / keys.Count),2);
            av.ThirdStep = Math.Round((av.ThirdStep / keys.Count),2);
            av.FourthStep = Math.Round((double)(av.FourthStep / keys.Count),2);
            av.FifthStep = Math.Round((double)(av.FifthStep / keys.Count),4)*100;
            av.Unsuccessful = (100- av.FifthStep);
            av.Next = Math.Round((double)(av.Next / (av.Next + av.Prev)),4)*100;
            av.Prev = Math.Round((100 - av.Next),2);
            return av;
        }

        public AverageTimeDTO ForLoop(NewExaminationTimeSpent nets, AverageTimeDTO av, TimeSpan time)
        {
            if ((int)nets.StepId == 1)
            {
                av.FirstStep += Convert.ToInt64(time.TotalSeconds);
            }
            else if ((int)nets.StepId == 2)
            {
                av.SecondStep += Convert.ToInt64(time.TotalSeconds);
            }
            else if ((int)nets.StepId == 3)
            {
                av.ThirdStep += Convert.ToInt64(time.TotalSeconds);
            }
            else if ((int)nets.StepId == 4)
            {
                av.FourthStep += Convert.ToInt64(time.TotalSeconds);
                av.FifthStep += 1;
            }

            return av;
        }

        public long GetMostVisitedRoom(string username)
        {

            List<DomainEvent> roomEvents = (List<DomainEvent>)GetAll("roomevent");
            List<RoomEvent> mostVisitedRoom = new List<RoomEvent>();
            int days = 3;
            foreach (RoomEvent r in roomEvents)
            {
                if (r.TimeStamp.Day <= DateTime.Now.Day && r.TimeStamp.Day >= DateTime.Now.Day - days && r.Username.Equals(username))
                {
                    mostVisitedRoom.Add(r);
                }
            }
            if (mostVisitedRoom.Count == 0)
                return 0;
            long mostVisitedRoomId = mostVisitedRoom.GroupBy(x => x.RoomId)
                .Select(group => new { RoomEventID = group.Key, Count = group.Count() })
                .OrderByDescending(x => x.Count).First().RoomEventID;

            return mostVisitedRoomId;

        }

        public MapEvent GetMostVisitedFloor(string username)
        {
            List<DomainEvent> mapEvents = (List<DomainEvent>)GetAll("mapevent");
            List<MapEvent> mostVisitedFloor = new List<MapEvent>();
            int days = 3;
            foreach (MapEvent m in mapEvents)
            {
                if (m.TimeStamp.Day <= DateTime.Now.Day && m.TimeStamp.Day >= DateTime.Now.Day - days && m.Username.Equals(username))
                    mostVisitedFloor.Add(m);
            }
            if (mostVisitedFloor.Count == 0)
                return null;
            var mostVisitedFloorId = mostVisitedFloor.GroupBy(x => new { x.BuildingName, x.FloorLevel, x.Username })
                .Select(group => new { MapEventID = group.Key, Count = group.Count() })
                .OrderByDescending(x => x.Count).First().MapEventID;

            MapEvent mapEvent = new MapEvent(mostVisitedFloorId.BuildingName, mostVisitedFloorId.FloorLevel, mostVisitedFloorId.Username);

            return mapEvent;
        }
    }
}
