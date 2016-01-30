#region

using Slack.Contracts;

#endregion

namespace Slack.Models
{
    public class SlackChannelConfig : ISlackChannelConfig
    {
        public string IconUrl { get; set; }
        public string ChannelName { get; set; }
    }
}