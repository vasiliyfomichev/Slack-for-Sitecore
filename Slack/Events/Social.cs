#region

using System;
using System.Linq;
using Sitecore.Events;
using Sitecore.Security.Accounts;
using Sitecore.Social.Client.Api.EventArgs;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;

#endregion

namespace Slack.Events
{
    // events don't fire for login/logout
    public class Social
    {
        #region Fields

        private readonly ISlackMessage _message;
        private readonly ISlackService _service;

        #endregion

        #region Constructors

        public Social()
        {
            _message = new SlackMessage();
            _service = new SlackService();
        }

        public Social(ISlackService service, ISlackMessage message)
        {
            _message = message;
            _service = service;
        }

        #endregion

        #region Methods

        public void OnUserCreated(object sender, EventArgs args)
        {
            var publications = _service.GetApplicablePublications(new Guid(Constants.EventIds.SocialUserCreatedEventGuid));
            if (!publications.Any())
                return;

            var login = Sitecore.Events.Event.ExtractParameter(args, 0);
            if (login == null) return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = "User Created";
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message);
                }
            }
        }

        public void OnUserLoggedIn(object sender, EventArgs args)
        {
            var publications = _service.GetApplicablePublications(new Guid(Constants.EventIds.SocialUserLoggedInEventGuid));
            if (!publications.Any())
                return;

            var login = Sitecore.Events.Event.ExtractParameter(args, 0);
            if (login == null) return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = "User Logged In";
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message);
                }
            }
        }

        public void OnUserProfileAttached(object sender, EventArgs args)
        {
            var publications = _service.GetApplicablePublications(new Guid(Constants.EventIds.SocialProfileAttachedEventGuid));
            if (!publications.Any())
                return;

            var login = Sitecore.Events.Event.ExtractParameter(args, 0);
            if (login == null) return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = "User Profile Attache";
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message);
                }
            }
        }

        #endregion
    }
}