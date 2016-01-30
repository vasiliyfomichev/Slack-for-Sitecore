using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Slack.Contracts;
using Slack.Models;

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