#region

using System;
using System.Linq;
using Sitecore.Events;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;

#endregion

namespace Slack.Events
{
    // events don't fire for indexing
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
            //var channelConfigs =
            //    _service.GetApplicableSlackChannelConfigs(new Guid(Constants.EventIds.IndexingBeginID));
            //if (!channelConfigs.Any())
            //    return;

            //var indexer = Event.ExtractParameter(args, 0);
            //if (indexer == null) return;
            //foreach (var channelConfig in channelConfigs)
            //{
            //    _message.Channel = channelConfig.ChannelName;
            //    //TODO: populate the rest of the message
            //    _service.PublishMessage(_message);
            //}
        }

        public void OnIndexingEnd(object sender, EventArgs args)
        {
            //var channelConfigs =
            //    _service.GetApplicableSlackChannelConfigs(new Guid(Constants.EventIds.IndexingEnd));
            //if (!channelConfigs.Any())
            //    return;
            //var indexer = Event.ExtractParameter(args, 0);
            //if (indexer == null) return;


            //foreach (var channelConfig in channelConfigs)
            //{
            //    _message.Channel = channelConfig.ChannelName;
            //    //TODO: populate the rest of the message
            //    _service.PublishMessage(_message);
            //}
        }

        #endregion
    }
}