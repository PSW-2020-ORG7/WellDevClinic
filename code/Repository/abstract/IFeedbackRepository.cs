using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bolnica.Model.Users;
using Repository;

namespace bolnica.Repository
{
    public interface IFeedbackRepository : IRepository<Feedback, long>
    {
    }
}
