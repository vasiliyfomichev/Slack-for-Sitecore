using Sitecore.Pipelines.Logout;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;
using System;
using System.Linq;

namespace Slack.Processors
{
    public class LogOut
    {
        #region Fields

        private readonly ISlackMessage _message;
        private readonly ISlackService _service;

        #endregion

        #region Constructors

        public LogOut()
        {
            _message = new SlackMessage();
            _service = new SlackService();
        }

        public LogOut(ISlackService service, ISlackMessage message)
        {
            _message = message;
            _service = service;
        }

        #endregion

        public void Process(LogoutArgs args)
        {
            if (args == null) return;
            var publications = _service.GetApplicablePublications(new Guid(Constants.PocessorEventIds.UserLogOut));
            if (!publications.Any())
                return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = $"User was logged out";
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message);
                }
            }
        }
    }
}