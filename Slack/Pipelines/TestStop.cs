
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics.Pipelines.RegisterPageEvent;
using Sitecore.Analytics.Pipelines.TriggerCampaign;
using Sitecore.ContentTesting.Pipelines.StartPageTest;
using Sitecore.ContentTesting.Pipelines.StartTest;
using Sitecore.ContentTesting.Pipelines.StopTest;
using Sitecore.ListManagement.ContentSearch.Pipelines;
using Sitecore.Pipelines;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;

namespace Slack.Pipelines
{
    public class TestStop
    {
        #region Fields

        private readonly ISlackMessage _message;
        private readonly ISlackService _service;

        #endregion

        #region Constructors

        public TestStop()
        {
            _message = new SlackMessage();
            _service = new SlackService();
        }

        public TestStop(ISlackService service, ISlackMessage message)
        {
            _message = message;
            _service = service;
        }

        #endregion

        public void Process(StopTestArgs args)
        {
            if (args == null) return;
            var channelConfigs =
                   _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Pipelines.TestStoppedEventId));
            if (!channelConfigs.Any())
                return;

            foreach (var channelConfig in channelConfigs)
            {
                _message.Text = $"Test stopped for {args.Configuration.ContentItem}. The winner is {args.WinnerVersion.Paths.Path}.";
                _message.Channel = channelConfig.ChannelName;
                //TODO: populate the rest of the message
                _service.PublishMessage(_message);
            }
        }
    }
}