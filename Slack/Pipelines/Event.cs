#region

using System;
using System.Linq;
using Sitecore.Analytics.Pipelines.RegisterPageEvent;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;

#endregion

namespace Slack.Pipelines
{
    public class Event
    {
        #region Fields

        private readonly ISlackMessage _message;
        private readonly ISlackService _service;

        #endregion

        #region Constructors

        public Event()
        {
            _message = new SlackMessage();
            _service = new SlackService();
        }

        public Event(ISlackService service, ISlackMessage message)
        {
            _message = message;
            _service = service;
        }

        #endregion

        public void Process(RegisterPageEventArgs args)
        {
            if (args == null) return;
            var publications = _service.GetApplicablePublications(new Guid(Constants.PipelineEventIds.PageEvent));
            if (!publications.Any())
                return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = $"Page event {args.PageEvent.Name} has been triggered.";
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message, true);
                }
            }
        }
    }
}