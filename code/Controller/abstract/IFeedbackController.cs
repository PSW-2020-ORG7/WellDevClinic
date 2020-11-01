using bolnica.Model.Users;
using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Controller
{
    public interface IFeedbackController : IController<Feedback,long>
    {
        void LeaveFeedback(Feedback feedback);

        Feedback GetFeedback(long id);


        void PublishFeedback(Feedback feedback);



    }
}
