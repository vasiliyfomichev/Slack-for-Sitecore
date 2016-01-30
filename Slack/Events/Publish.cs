#region 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Configuration;
using Sitecore.Events;
using Sitecore.Publishing;
using Sitecore.SecurityModel;
using Slack.Contracts;
using Slack.Models;
using Slack.Services; 
#endregion

namespace Slack.Events
{
    public class Publish
    {

        #region Fields

        private readonly ISlackMessage _message;
        private readonly ISlackService _service;

        #endregion

        #region Constructors

        public Publish()
        {
           _message = new SlackMessage();
            _service = new SlackService(); 
        }

        public Publish(ISlackService service, ISlackMessage message)
        {
            _message = message;
            _service = service;
        }

        #endregion

        #region Methods

        public void OnPublishBegin(object sender, EventArgs args)
        {
            var channelConfigs =
                _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Events.PublishBeginEventID));
            if (!channelConfigs.Any())
                return;

            var publisher = Event.ExtractParameter(args, 0) as Publisher;
            if (publisher == null) return;
            foreach (var channelConfig in channelConfigs)
            { 
                _message.Text = PopulatePublishMessage(publisher, "was initiated");
                _message.Channel = channelConfig.ChannelName;
                //TODO: populate the rest of the message
                _service.PublishMessage(_message);
            }
        }

        public void OnPublishEnd(object sender, EventArgs args)
        {
            var channelConfigs =
                _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Events.PublishEndEventID));
            if (!channelConfigs.Any())
                return;
            var publisher = Event.ExtractParameter(args, 0) as Publisher;
            if (publisher == null) return;
            

            foreach (var channelConfig in channelConfigs)
            {
                _message.Text = PopulatePublishMessage(publisher, "ended");
                _message.Channel = channelConfig.ChannelName;
                //TODO: populate the rest of the message
                _service.PublishMessage(_message);
            }
        }

        public void OnPublishFail(object sender, EventArgs args)
        {
            var channelConfigs =
                _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Events.PublishFailedEventId));
            if (!channelConfigs.Any())
                return;
            var publisher = Event.ExtractParameter(args, 0) as Publisher;
            if (publisher == null) return;


            foreach (var channelConfig in channelConfigs)
            {
                _message.Text = PopulatePublishMessage(publisher, "failed");
                _message.Channel = channelConfig.ChannelName;
                //TODO: populate the rest of the message
                _service.PublishMessage(_message);
            }
        }

        private static string PopulatePublishMessage(Publisher publisher, string action)
        {
            using (new SecurityDisabler())
            {
                var database =
                    Factory.GetDatabase(Settings.GetSetting("Slack.AuthoringDatabase", "master"));
                var message =
                    $"{(publisher.Options.RepublishAll ? "Republish" : "Publish")} {action} to {string.Join(", ", publisher.Options.PublishingTargets.Select(i => database.GetItem(i).Paths.Path))} database: \n " +
                    $"User: {publisher.Options.UserName}\n" +
                    $"Mode: {publisher.Options.Mode} \n" +
                    $"Root Item: {publisher.Options.RootItem.Paths.Path}\n" +
                    $"Language: {publisher.Options.Language} \n" +
                    $"Publish Subitems: {publisher.Options.Deep} \n";
                if (publisher.Options.Mode == PublishMode.SingleItem)
                {
                    message += $"Publish Subitems: {publisher.Options.Deep} \n" +
                               $"Publish Related Items: {publisher.Options.PublishRelatedItems}";
                }

                return message;
            }
        }

        #endregion
    }
}