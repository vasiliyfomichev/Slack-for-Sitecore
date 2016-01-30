using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Slack.Contracts;

namespace Slack.Models
{
    public class SlackChannelConfig:ISlackChannelConfig
    {
        public string IconUrl { get; set; }
        public string ChannelName { get; set; }
    }
}