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
            if (args == null) return;
            var publications = _service.GetApplicablePublications(new Guid(Constants.Pipelines.ListDeletionEventId));
            if (!publications.Any())
                return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = $"List {args.ContactList.Name} has been deleted.";
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message);
                }
            }
        }
    }
}