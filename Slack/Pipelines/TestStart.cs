#region

using System;
using System.Linq;
using Sitecore.ContentTesting.Pipelines.StartTest;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;

#endregion

namespace Slack.Pipelines
{
    public class TestStart
    {
        #region Fields

        private readonly ISlackMessage _message;
        private readonly ISlackService _service;

        #endregion

        #region Constructors

        public TestStart()
        {
            _message = new SlackMessage();
            _service = new SlackService();
        }

        public TestStart(ISlackService service, ISlackMessage message)
        {
            _message = message;
            _service = service;
        }

        #endregion

        public void Process(StartTestArgs args)
        {
            if (args == null) return;
            var channelConfigs =
                _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Pipelines.TestStartedEventId));
            if (!channelConfigs.Any())
                return;

            foreach (var channelConfig in channelConfigs)
            {
                _message.Text = $"Test started for {args.HostItem.Paths.Path}.";
                _message.Channel = channelConfig.ChannelName;
                //TODO: populate the rest of the message
                _service.PublishMessage(_message);
            }
        }
    }
}