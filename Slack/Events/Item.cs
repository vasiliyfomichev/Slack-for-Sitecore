#region

using System;
using System.Linq;
using Sitecore.Data.Events;
using Sitecore.Events;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;
using Sitecore.Data;

#endregion

namespace Slack.Events
{
    // events don't fire for login/logout
    public class Item
    {
        #region Fields

        private readonly ISlackMessage _message;
        private readonly ISlackService _service;

        #endregion

        #region Constructors

        public Item()
        {
            _message = new SlackMessage();
            _service = new SlackService();
        }

        public Item(ISlackService service, ISlackMessage message)
        {
            _message = message;
            _service = service;
        }

        #endregion

        #region Methods

        public void OnItemCreated(object sender, EventArgs args)
        {
            var publications = _service.GetApplicablePublications(new Guid(Constants.EventIds.OnItemCreated));
            if (!publications.Any())
                return;

            var itemEvent = Sitecore.Events.Event.ExtractParameter(args, 0) as ItemCreatedEventArgs;
            if (itemEvent == null) return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = PopulateItemCreatedMessage(publication, itemEvent, "was created");
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message);
                }
            }
        }

        public void OnItemDeleted(object sender, EventArgs args)
        {
            var publications = _service.GetApplicablePublications(new Guid(Constants.EventIds.OnItemDeleted));
            if (!publications.Any())
                return;

            var itemEvent = Sitecore.Events.Event.ExtractParameter(args, 0) as Sitecore.Data.Items.Item;
            if (itemEvent == null) return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = PopulateItemMessage(publication, itemEvent, "was deleted");
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message);
                }
            }
        }

        public void OnItemMoved(object sender, EventArgs args)
        {
            var publications = _service.GetApplicablePublications(new Guid(Constants.EventIds.OnItemMoved));
            if (!publications.Any())
                return;

            var itemEvent = Sitecore.Events.Event.ExtractParameter(args, 0) as Sitecore.Data.Items.Item;
            if (itemEvent == null) return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = PopulateItemMessage(publication, itemEvent, "was moved");
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message);
                }
            }
        }

        private static string PopulateItemCreatedMessage(Publication publication, ItemCreatedEventArgs itemEvent, string action)
        {
            var message = "";
            if (!string.IsNullOrEmpty(publication.Message))
            {
                message = publication.Message + "\n";
            }
            message +=
                $"Item {itemEvent.Item.Name} {action}\n" +
                $"Path: {itemEvent.Item.Paths.Path}\n" +
                $"ID: {itemEvent.Item.ID}\n" +
                $"Created by: {itemEvent.Item.Security.GetOwner()}\n";
            return message;
        }

        private static string PopulateItemMessage(Publication publication, Sitecore.Data.Items.Item itemEvent, string action)
        {
            var message = "";
            if (!string.IsNullOrEmpty(publication.Message))
            {
                message = publication.Message + "\n";
            }
            message +=
                $"Item {itemEvent.Name} {action}\n" +
                $"ID: {itemEvent.ID}\n" +
                $"Path: {itemEvent.Paths.Path}\n";
            return message;
        }
        #endregion
    }
}