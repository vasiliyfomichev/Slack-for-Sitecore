using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Configuration;
using Sitecore.Data;
using Slack.Contracts;
using Slack.Models;
using SlackConnector;
using SlackConnector.Models;

namespace Slack.Services
{
    internal class SlackService : ISlackService
    {
        #region Interface Implementations

        public void PublishMessage(ISlackMessage slackMessage)
        {
            if (string.IsNullOrWhiteSpace(slackMessage.Token) 
                || string.IsNullOrWhiteSpace(slackMessage.Channel)
                || string.IsNullOrWhiteSpace(slackMessage.Username)
                || string.IsNullOrWhiteSpace(slackMessage.Text))
                return;

            var slackConnector = new SlackConnector.SlackConnector();
            var connection = slackConnector.Connect(slackMessage.Token).Result;
            var message = new BotMessage
            {
                Text = slackMessage.Text,
                ChatHub =
                    connection.ConnectedChannels()
                        .First(
                            x => x.Name.Equals("#" + slackMessage.Channel.Trim('#'), StringComparison.InvariantCultureIgnoreCase))
            };

            // when
            connection.Say(message).Wait();
        }

        public IList<Publication> GetApplicablePublications(Guid eventId)
        {
            var item = Database.GetDatabase(Settings.GetSetting("Slack.AuthoringDatabase", "master")).GetItem(Constants.PublicationFolder.InstanceId);

            var publicationFolder = new Publication_Folder(item);
            var publications = publicationFolder.GetPublications();

            return publications.Where(publication => publication.Events.Contains(ID.Parse(eventId))).ToList();
        }

        #endregion
    }
}