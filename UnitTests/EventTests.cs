using EventSourcing;
using EventSourcing.Repository;
using EventSourcing.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class EventTests
    {
        private static IDomainEventRepository CreateEventRepository()
        {
            var stubRepository = new Mock<IDomainEventRepository>();
            List<NewExaminationTimeSpent> list = new List<NewExaminationTimeSpent>();
            list.Add(new NewExaminationTimeSpent(1, StepIds.DATE, StepTypes.NEXT, 1));
            list.Add(new NewExaminationTimeSpent(1, StepIds.DOCTOR, StepTypes.BACK, 1));
            stubRepository.Setup(n => n.GetAll("newexaminationtimespent")).Returns(list);

            return stubRepository.Object;
        }

        [Fact]
        public void GetStepTypes()
        {
            DomainEventService service = new DomainEventService(CreateEventRepository());
            List<NewExaminationTimeSpent> netss = (List<NewExaminationTimeSpent>)service.GetAll("newexaminationtimespent");
            List<StepTypes> stepTypes = new List<StepTypes>();
            foreach (NewExaminationTimeSpent nets in netss)
            {
                stepTypes.Add(nets.StepType);
            }
            Assert.NotEmpty(stepTypes);
        }

        /*[Fact]
        public void CalculateTimes()
        {
            DomainEventService service = new DomainEventService(CreateEventRepository());
        }*/
    }
}
