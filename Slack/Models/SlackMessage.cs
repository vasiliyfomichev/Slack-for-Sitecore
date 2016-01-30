#region

using Slack.Contracts;

#endregion

namespace Slack.Models
{
    public class SlackMessage : ISlackMessage
    {
        public string Token { get; set; }
        public string Channel { get; set; }
        public string Text { get; set; }
        public string Username { get; set; }
        public bool AsUser { get; set; }
        public string IconUrl { get; set; }
    }
}