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
    public class Package
    {
        #region Fields

        private readonly ISlackMessage _message;
        private readonly ISlackService _service;

        #endregion

        #region Constructors

        public Package()
        {
            _message = new SlackMessage();
            _service = new SlackService();
        }

        public Package(ISlackService service, ISlackMessage message)
        {
            _message = message;
            _service = service;
        }

        #endregion

        #region Methods

        public void OnPackageInstallStarted(object sender, EventArgs args)
        {
            var channelConfigs =
                _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Events.PackageInstallStartedEventGuid));
            if (!channelConfigs.Any())
                return;

            var package = Event.ExtractParameter(args, 0);
            if (package == null) return;
            foreach (var channelConfig in channelConfigs)
            {
                _message.Text = "A package install started.";
                _message.Channel = channelConfig.ChannelName;
                //TODO: populate the rest of the message
                _service.PublishMessage(_message);
            }
        }

        public void OnPackageInstallEnded(object sender, EventArgs args)
        {
            var channelConfigs =
                _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Events.PackageInstallStartedEventGuid));
            if (!channelConfigs.Any())
                return;
            var publisher = Event.ExtractParameter(args, 0) as Publisher;
            if (publisher == null) return;
            foreach (var channelConfig in channelConfigs)
            {
                _message.Text = "A package install completed.";
                _message.Channel = channelConfig.ChannelName;
                //TODO: populate the rest of the message
                _service.PublishMessage(_message);
            }
        }

        #endregion


    }
}