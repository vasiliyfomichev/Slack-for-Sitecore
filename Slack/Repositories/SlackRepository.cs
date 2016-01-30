using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Slack.Contracts;

namespace Slack.Repositories
{
    internal class SlackRepository : ISlackRepository
    {
        public void PublishMessage(ISlackMessage message)
        {
            throw new NotImplementedException();
        }
    }
}