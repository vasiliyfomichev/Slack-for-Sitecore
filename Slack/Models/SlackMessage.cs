#region

using Slack.Contracts;

#endregion

namespace Slack.Models
{
    public class SlackMessage : ISlackMessage
    {
        #region Properties

        public string Token { get; set; }
        public string Channel { get; set; }
        public string Text { get; set; }
        public string Username { get; set; }
        public bool AsUser { get; set; }
        public string IconUrl { get; set; }

        #endregion

        #region Methods

        public void UpdateChannelInfo(Channel channel, Publication publication)
        {
            var teamContext = publication.GetTeamContext();
            if (teamContext == null)
                return;

            Channel = channel.ChannelName;
            Token = teamContext.Token;
            Username = teamContext.Username;
        }

        #endregion
    }
}