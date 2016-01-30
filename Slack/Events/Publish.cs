using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Events;
using Sitecore.Publishing;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;

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

        public void OnPublishStart(object sender, EventArgs args)
        {
            var publisher = Event.ExtractParameter(args, 0) as Publisher;
            if (publisher == null) return;
            _message.Text = PopulatePublishMessage(publisher, "was initiated");
            //TODO: populate the rest of the message
            _service.PublishMessage(_message);
        }

        public void OnPublishEnd(object sender, EventArgs args)
        {
            var publisher = Event.ExtractParameter(args, 0) as Publisher;
            if (publisher == null) return;
            _message.Text = PopulatePublishMessage(publisher, "ended");

            //TODO: populate the rest of the message
            _service.PublishMessage(_message);
        }

        private static string PopulatePublishMessage(Publisher publisher, string action)
        {
            var message = $"{(publisher.Options.RepublishAll ? "Republish" : "Publish")} {action} to {string.Join(", ", publisher.Options.PublishingTargets)} database: \n " +
                          $"User: {publisher.Options.UserName}\n"+
                          $"Mode: {publisher.Options.Mode} \n" +
                          $"Root Item: {publisher.Options.RootItem.Paths.Path}\n" +
                          $"Language: {publisher.Options.Language} \n" +
                          $" {publisher.Options.Deep} \n";
            if (publisher.Options.Mode == PublishMode.SingleItem)
            {
                message += $"Publish Subitems: {publisher.Options.Deep} \n" +
                           $"Publish Related Items: {publisher.Options.PublishRelatedItems}";
            }

            return message;
        }

        #endregion
    }
}