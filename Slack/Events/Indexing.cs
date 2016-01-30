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
    public class Indexing
    {
        #region Fields

        private readonly ISlackMessage _message;
        private readonly ISlackService _service;

        #endregion

        #region Constructors

        public Indexing()
        {
            _message = new SlackMessage();
            _service = new SlackService();
        }

        public Indexing(ISlackService service, ISlackMessage message)
        {
            _message = message;
            _service = service;
        }

        #endregion

        #region Methods

        public void OnIndexingStart(object sender, EventArgs args)
        {
            var channelConfigs =
                _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Events.IndexingBeginID));
            if (!channelConfigs.Any())
                return;

            var indexer = Event.ExtractParameter(args, 0);
            if (indexer == null) return;
            foreach (var channelConfig in channelConfigs)
            {
                
                _message.Channel = channelConfig.ChannelName;
                //TODO: populate the rest of the message
                _service.PublishMessage(_message);
            }
        }

        public void OnIndexingEnd(object sender, EventArgs args)
        {
            var channelConfigs =
                _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Events.IndexingEndID));
            if (!channelConfigs.Any())
                return;
            var indexer = Event.ExtractParameter(args, 0);
            if (indexer == null) return;


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