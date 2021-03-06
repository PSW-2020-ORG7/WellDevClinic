﻿using SearchAndSchedule_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.ApplicationServices.Abstract
{
    public interface IOperationAppService : ICRUD<Operation, long>
    {
        List<Operation> GetOperationsByDoctor(Doctor doctor);

        List<Operation> GetOperationsByRoomAndPeriod(Room room, Period period);
    }
}
