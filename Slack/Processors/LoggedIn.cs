using Sitecore.Pipelines;
using Sitecore.Pipelines.LoggedIn;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;
using System;
using System.Linq;

namespace Slack.Processors
{
    public class LoggedIn
    {
        #region Fields

        private readonly ISlackMessage _message;
        private readonly ISlackService _service;

        #endregion

        #region Constructors

        public LoggedIn()
        {
            _message = new SlackMessage();
            _service = new SlackService();
        }

        public LoggedIn(ISlackService service, ISlackMessage message)
        {
            _message = message;
            _service = service;
        }

        #endregion

        public void Process(PipelineArgs args)
        {
            if (args == null) return;
            var publications = _service.GetApplicablePublications(new Guid(Constants.PocessorEventIds.UserLoggedIn));
            if (!publications.Any())
                return;

            var user = args as LoggedInArgs;
            if (user == null) return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = PopulateSecurityrMessage(publication, user, "was logged in");
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message, true);
                }
            }
        }

        private static string PopulateSecurityrMessage(Publication publication, LoggedInArgs user, string action)
        {
            var message = string.Empty;
            if (!string.IsNullOrEmpty(publication.Message))
            {
                message = publication.Message + "\n";
            }
            message += $"User {action}\n" +
                $"User: {user.Username}\n";
            return message;

        }
    }
}