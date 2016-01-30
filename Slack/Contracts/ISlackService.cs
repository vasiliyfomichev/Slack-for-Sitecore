#region

using System;
using System.Collections.Generic;

#endregion

namespace Slack.Contracts
{
    public interface ISlackService
    {
        void PublishMessage(ISlackMessage message);

        IList<Publication> GetApplicablePublications(Guid eventId);
    }
}