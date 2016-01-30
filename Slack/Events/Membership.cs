#region

using System;
using System.Linq;
using System.Web.Security;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;

#endregion

namespace Slack.Events
{
    public class Membership
    {
        #region Fields

        private readonly ISlackMessage _message;
        private readonly ISlackService _service;

        #endregion

        #region Constructors

        public Membership()
        {
            _message = new SlackMessage();
            _service = new SlackService();
        }

        public Membership(ISlackService service, ISlackMessage message)
        {
            _message = message;
            _service = service;
        }

        #endregion

        #region Methods

        public void OnUserCreated(object sender, EventArgs args)
        {
            var publications = _service.GetApplicablePublications(new Guid(Constants.Events.OnUserCreated));
            if (!publications.Any())
                return;

            var membershipUser = Sitecore.Events.Event.ExtractParameter(args, 0) as MembershipUser;
            if (membershipUser == null) return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = PopulateMembershipUserMessage(publication, membershipUser, "was initiated");
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message);
                }
            }
        }

        public void OnUserDeleted(object sender, EventArgs args)
        {
            var publications = _service.GetApplicablePublications(new Guid(Constants.Events.OnUserDeleted));
            if (!publications.Any())
                return;

            var membershipUser = Sitecore.Events.Event.ExtractParameter(args, 0);
            if (membershipUser == null) return;
            var message = string.Empty;

            foreach (var publication in publications)
            {
                if (!string.IsNullOrEmpty(publication.Message))
                {
                    message = publication.Message + "\n";
                }
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = $"{message} User {membershipUser} was deleted.";
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message);

                }
            }
        }

        public void OnRoleCreated(object sender, EventArgs args)
        {
            var publications = _service.GetApplicablePublications(new Guid(Constants.Events.OnRoleCreated));
            if (!publications.Any())
                return;

            var membershipRole = Sitecore.Events.Event.ExtractParameter(args, 0) as string;
            if (membershipRole == null) return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = $"Role {membershipRole} was created.";
                    //TODO: populate the rest of the message
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message);
                }
            }
        }

        public void OnRoleDeleted(object sender, EventArgs args)
        {
            var publications = _service.GetApplicablePublications(new Guid(Constants.Events.OnRoleDeleted));
            if (!publications.Any())
                return;

            var membershipRole = Sitecore.Events.Event.ExtractParameter(args, 0) as string;
            if (membershipRole == null) return;

            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = $"Role {membershipRole} was deleted.";
                    //TODO: populate the rest of the message
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message);
                }
            }
        }


        private static string PopulateMembershipUserMessage(Publication publication, MembershipUser membershipUser, string action)
        {
            var message = string.Empty;
            if (!string.IsNullOrEmpty(publication.Message))
            {
                message = publication.Message + "\n";
            }
            message +=
                $"User {membershipUser.UserName} {action}\n" +
                $"Email: {membershipUser.Email}\n";
            return message;

        }
        #endregion
    }
}