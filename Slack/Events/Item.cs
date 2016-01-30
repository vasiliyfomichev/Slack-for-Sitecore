#region

using System;
using System.Linq;
using Sitecore.Data.Events;
using Sitecore.Events;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;

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
            //var channelConfigs =
            //    _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Events.ItemCreatedID));
            //if (!channelConfigs.Any())
            //    return;

            //var item = Event.ExtractParameter(args, 0) as ItemCreatedEventArgs;
            //if (item == null) return;
            //foreach (var channelConfig in channelConfigs)
            //{
            //    _message.Text = $"Item {item.Item.Paths.Path} was created.";
            //    _message.Channel = channelConfig.ChannelName;
            //    //TODO: populate the rest of the message
            //    _service.PublishMessage(_message);
            //}
        }

        public void OnItemDeleted(object sender, EventArgs args)
        {
            //var channelConfigs =
            //    _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Events.ItemDeletedID));
            //if (!channelConfigs.Any())
            //    return;
            //var item = Event.ExtractParameter(args, 0) as ItemDeletedEventArgs;
            //if (item == null) return;


            //foreach (var channelConfig in channelConfigs)
            //{
            //    _message.Text = $"Item {item.Item.Paths.Path} was deleted.";
            //    _message.Channel = channelConfig.ChannelName;
            //    //TODO: populate the rest of the message
            //    _service.PublishMessage(_message);
            //}
        }

        public void OnItemMoved(object sender, EventArgs args)
        {
            //var channelConfigs =
            //    _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Events.ItemMovedID));
            //if (!channelConfigs.Any())
            //    return;
            //var item = Event.ExtractParameter(args, 0) as ItemMovedEventArgs;
            //if (item == null) return;


            //foreach (var channelConfig in channelConfigs)
            //{
            //    _message.Text = $"Item {item.Item.Paths.Path} was moved.";
            //    _message.Channel = channelConfig.ChannelName;
            //    //TODO: populate the rest of the message
            //    _service.PublishMessage(_message);
            //}
        }

        #endregion
    }
}