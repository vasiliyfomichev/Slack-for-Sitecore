using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Events;
using Sitecore.Publishing;

namespace Slack.Events
{
    public class Publish
    {
        public void OnPublishEnd(object sender, EventArgs args)
        {
            var publisher = Event.ExtractParameter(args, 0) as Publisher;
        }
    }
}