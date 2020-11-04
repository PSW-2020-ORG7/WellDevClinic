using bolnica.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Service
{
    interface IFeedbackService
    {
        Feedback LeaveFeedback(Feedback feedback);

        Feedback GetFeedback(long id);

        List<Feedback> GetAllFeedback();

        void PublishFeedback(Feedback feedback);
    }
}
