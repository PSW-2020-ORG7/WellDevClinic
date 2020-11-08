using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Model.Users
{
    /// <summary>
    /// Models a feedback
    /// </summary>
    public class Feedback:IIdentifiable<long>
    {
        public long Id { get; set; }

        private string patient;

        private String content;

        private bool isPrivate;

        private bool publish;

        private bool isAnonymous;

        public Feedback()
        {
        }

        public Feedback(long id, string patient, string content, bool isPrivate, bool publish, bool isAnonymous)
        {
            this.Id = id;
            this.patient = patient;
            this.content = content;
            this.isPrivate = isPrivate;
            this.publish = publish;
            this.isAnonymous = isAnonymous;
        }
        
        public string Patient { get => patient; set => patient = value; }
        public string Content { get => content; set => content = value; }
        public bool IsPrivate { get => isPrivate; set => isPrivate = value; }
        public bool Publish { get => publish; set => publish = value; }
        public bool IsAnonymous { get => isAnonymous; set => isAnonymous = value; }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            this.Id = id;
        }
    }
}
