using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Slack.Contracts;

namespace Slack.Services
{
    internal class SlackService : ISlackService
    {
        public void PublishMessage(ISlackMessage message)
        {
            throw new NotImplementedException();
        }
    }
}