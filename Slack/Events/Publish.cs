﻿#region 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Configuration;
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

        //TODO: After the hackathon we should introduce Dependency Injection 
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
            var publications = _service.GetApplicablePublications(new Guid(Constants.EventIds.OnPublishBegin));
            if (!publications.Any())
                return;

            var publisher = Sitecore.Events.Event.ExtractParameter(args, 0) as Publisher;
            if (publisher == null) return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = PopulatePublishMessage(publication, publisher, "was initiated");
                    _message.Channel = channel.ChannelName;
                    var teamContext = publication.GetTeamContext();
                    _message.Token = teamContext.Token;
                    _message.Username = teamContext.Username;
                    _service.PublishMessage(_message);
                }
            }
        }

        public void OnPublishEnd(object sender, EventArgs args)
        {
            var publications = _service.GetApplicablePublications(new Guid(Constants.EventIds.OnPublishEnd));
            if (!publications.Any())
                return;

            var publisher = Sitecore.Events.Event.ExtractParameter(args, 0) as Publisher;
            if (publisher == null) return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = PopulatePublishMessage(publication, publisher, "ended");
                    _message.Channel = channel.ChannelName;
                    var teamContext = publication.GetTeamContext();
                    _message.Token = teamContext.Token;
                    _message.Username = teamContext.Username;
                    _service.PublishMessage(_message);
                }
            }
        }

        public void OnPublishFail(object sender, EventArgs args)
        {
            var publications = _service.GetApplicablePublications(new Guid(Constants.EventIds.OnPublishEnd));
            if (!publications.Any())
                return;
            var publisher = Sitecore.Events.Event.ExtractParameter(args, 0) as Publisher;
            if (publisher == null) return;


            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = PopulatePublishMessage(publication, publisher, "failed");
                    _message.Channel = channel.ChannelName;
                    var teamContext = publication.GetTeamContext();
                    _message.Token = teamContext.Token;
                    _message.Username = teamContext.Username;
                    _service.PublishMessage(_message);
                }
            }
        }

        private static string PopulatePublishMessage(Publication publication, Publisher publisher, string action)
        {
            using (new SecurityDisabler())
            {
                var database =
                    Factory.GetDatabase(Settings.GetSetting("Slack.AuthoringDatabase", "master"));
                var message = "";
                if (!string.IsNullOrEmpty(publication.Message))
                {
                    message = publication.Message + "\n";
                }
                var rootItem = publisher.Options.RootItem != null
                    ? publisher.Options.RootItem.Paths.Path
                    : "site publish";
                message +=
                    $"*{(publisher.Options.RepublishAll ? "Republish" : "Publish")}* {action} to *{string.Join(", ", publisher.Options.PublishingTargets.Select(i => database.GetItem(i).DisplayName))}* database: \n " +
                    $"User: {publisher.Options.UserName}\n" +
                    $"Mode: {publisher.Options.Mode} \n" +
                    
                    $"Root Item: " + rootItem + "\n" +
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