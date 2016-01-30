#region

using System;
using System.Linq;
using Sitecore.Events;
using Sitecore.Publishing;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;

#endregion

namespace Slack.Events
{
    // events don't fire for login/logout
    public class Security
    {
        #region Fields

        private readonly ISlackMessage _message;
        private readonly ISlackService _service;

        #endregion

        #region Constructors

        public Security()
        {
            _message = new SlackMessage();
            _service = new SlackService();
        }

        public Security(ISlackService service, ISlackMessage message)
        {
            _message = message;
            _service = service;
        }

        #endregion

        #region Methods

        public void OnLoggedIn(object sender, EventArgs args)
        {
            var publications = _service.GetApplicablePublications(new Guid(Constants.EventIds.OnLoggedIn));
            if (!publications.Any())
                return;

            var login = Sitecore.Events.Event.ExtractParameter(args, 0);
            if (login == null) return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = "On Logged In";
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message);
                }
            }
        }

        public void OnLoggedOut(object sender, EventArgs args)
        {
            var publications = _service.GetApplicablePublications(new Guid(Constants.EventIds.OnLoggedOut));
            if (!publications.Any())
                return;

            var login = Sitecore.Events.Event.ExtractParameter(args, 0);
            if (login == null) return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = "On Logged Out";
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message);
                }
            }
        }

        #endregion
    }
}