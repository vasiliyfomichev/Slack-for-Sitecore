#region

using System;
using System.Linq;
using Sitecore.Analytics.Pipelines.TriggerCampaign;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;

#endregion

namespace Slack.Pipelines
{
    public class Campaign
    {
        #region Fields

        private readonly ISlackMessage _message;
        private readonly ISlackService _service;

        #endregion

        #region Constructors

        public Campaign()
        {
            _message = new SlackMessage();
            _service = new SlackService();
        }

        public Campaign(ISlackService service, ISlackMessage message)
        {
            _message = message;
            _service = service;
        }

        #endregion

        public void Process(TriggerCampaignArgs args)
        {
            if (args == null) return;
            var channelConfigs =
                _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Pipelines.CampaignTriggeredEventId));
            if (!channelConfigs.Any())
                return;

            foreach (var channelConfig in channelConfigs)
            {
                _message.Text = $"Campaign {args.PageEvent.Name} has been triggered.";
                _message.Channel = channelConfig.ChannelName;
                //TODO: populate the rest of the message
                _service.PublishMessage(_message);
            }
        }
    }
}