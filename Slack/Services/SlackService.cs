#region

using System;
using System.Collections.Generic;
using Slack.Contracts;

#endregion

namespace Slack.Services
{
    internal class SlackService : ISlackService
    {
        public void PublishMessage(ISlackMessage message)
        {
            throw new NotImplementedException();
        }

        public IList<ISlackChannelConfig> GetApplicableSlackChannelConfigs(Guid eventId)
        {
            throw new NotImplementedException();
        }
    }
}