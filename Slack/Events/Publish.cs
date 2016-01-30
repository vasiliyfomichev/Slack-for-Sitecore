using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Slack.Events
{
    public class Publish
    {
        public void OnPublishEnd(object sender, EventArgs args)
        {
            //Publisher publisher = Event.ExtractParameter(args, 0) as Publisher;
        }
    }
}