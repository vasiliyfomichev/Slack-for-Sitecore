using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Glass.Mapper.Sc;
using Sitecore.Data;
using Slack.Contracts;
using Slack.Models;
using SlackConnector;
using SlackConnector.Models;

namespace Slack.Services
{
    internal class SlackService : ISlackService
    {
        public void PublishMessage(ISlackMessage slackMessage)
        {
            var slackConnector = new SlackConnector.SlackConnector();
            var connection = slackConnector.Connect(slackMessage.Token).Result;
            var message = new BotMessage
            {
                Text = slackMessage.Text,
                ChatHub = connection.ConnectedChannels().First(x => x.Name.Equals("#" + slackMessage.Channel, StringComparison.InvariantCultureIgnoreCase))
            };

            // when
            connection.Say(message).Wait();
        }

        public IList<Publication> GetApplicablePublications(Guid eventId)
        {
            var item = Sitecore.Data.Database.GetDatabase("master").GetItem(Publication_Folder.InstanceId);

            var publicationFolder = new Publication_Folder(item);
            var publications = publicationFolder.GetPublications();

            return publications.Where(publication => publication.Events.Contains(ID.Parse(eventId))).ToList();
        }
        
    }
}