#region

using System;
using System.Linq;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;
using Sitecore.Install.Events;

#endregion

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
            var publications = _service.GetApplicablePublications(new Guid(Constants.Events.OnPackageInstallStart));
            if (!publications.Any())
                return;

            var installationEvent = Sitecore.Events.Event.ExtractParameter(args, 0) as InstallationEventArgs;
            if (installationEvent == null) return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = "A package install started.";
                    //TODO: populate the rest of the message
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message);
                }
            }
        }

        public void OnPackageInstallEnded(object sender, EventArgs args)
        {
            var publications = _service.GetApplicablePublications(new Guid(Constants.Events.OnPackageInstallEnd));
            if (!publications.Any())
                return;

            var installationEvent = Sitecore.Events.Event.ExtractParameter(args, 0) as InstallationEventArgs;
            if (installationEvent == null) return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = "A package install completed.";
                    //TODO: populate the rest of the message
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message);
                }
            }
        }

        #endregion
    }
}