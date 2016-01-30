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
            var publications = _service.GetApplicablePublications(new Guid(Constants.Pipelines.CampaignTriggeredEventId));
            if (!publications.Any())
                return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = $"Campaign {args.Definition.DisplayName} has been triggered.";
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message);
                }
            }
        }
    }
}