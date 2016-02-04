#region

using System;
using System.Collections.Generic;
using Slack.Models;

#endregion

namespace Slack.Contracts
{
    public interface ISlackService
    {
        void PublishMessage(ISlackMessage message, bool async = false);

        IList<Publication> GetApplicablePublications(Guid eventId);
    }
}