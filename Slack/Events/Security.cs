using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Events;
using Sitecore.Pipelines.LoggedIn;
using Sitecore.Publishing;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;

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
            var channelConfigs =
                _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Events.LoggedInEventId));
            if (!channelConfigs.Any())
                return;

            var publisher = Event.ExtractParameter(args, 0);
            if (publisher == null) return;
            foreach (var channelConfig in channelConfigs)
            {
                
                _message.Channel = channelConfig.ChannelName;
                //TODO: populate the rest of the message
                _service.PublishMessage(_message);
            }
        }

        public void OnLoggedOut(object sender, EventArgs args)
        {
            var channelConfigs =
                _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Events.LoggedOutEventId));
            if (!channelConfigs.Any())
                return;
            var publisher = Event.ExtractParameter(args, 0) as Publisher;
            if (publisher == null) return;


            foreach (var channelConfig in channelConfigs)
            {
                
                _message.Channel = channelConfig.ChannelName;
                //TODO: populate the rest of the message
                _service.PublishMessage(_message);
            }
        }

        #endregion


    }
}