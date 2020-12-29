using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing
{
    public class FeedbackSubmittedEvent : DomainEvent
    {
        public long FeedbackId { get; private set; }

        public String Content { get; private set; }

        public FeedbackSubmittedEvent(long FeedbackId, String Content) : base()
        {
            this.FeedbackId = FeedbackId;
            this.Content = Content;
        }
    }
}
