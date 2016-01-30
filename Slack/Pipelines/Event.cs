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
            //if (args == null) return;
            //var channelConfigs =
            //    _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Pipelines.PageEventEventId));
            //if (!channelConfigs.Any())
            //    return;

            //foreach (var channelConfig in channelConfigs)
            //{
            //    _message.Text = $"Page event {args.PageEvent.Name} has been triggered.";
            //    _message.Channel = channelConfig.ChannelName;
            //    TODO: populate the rest of the message
            //    _service.PublishMessage(_message);
            //}
        }
    }
}