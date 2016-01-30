#region

using System;
using System.Linq;
using Sitecore.ListManagement.ContentSearch.Pipelines;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;

#endregion

namespace Slack.Pipelines
{
    public class ListDeletion
    {
        #region Fields

        private readonly ISlackMessage _message;
        private readonly ISlackService _service;

        #endregion

        #region Constructors

        public ListDeletion()
        {
            _message = new SlackMessage();
            _service = new SlackService();
        }

        public ListDeletion(ISlackService service, ISlackMessage message)
        {
            _message = message;
            _service = service;
        }

        #endregion

        public void Process(ListArgs args)
        {
            //if (args == null) return;
            //var channelConfigs =
            //    _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Pipelines.ListDeletionEventId));
            //if (!channelConfigs.Any())
            //    return;

            //foreach (var channelConfig in channelConfigs)
            //{
            //    _message.Text = $"List {args.ContactList.Name} has been deleted.";
            //    _message.Channel = channelConfig.ChannelName;
            //    //TODO: populate the rest of the message
            //    _service.PublishMessage(_message);
            //}
        }
    }
}