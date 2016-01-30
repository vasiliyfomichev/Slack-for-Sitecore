using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Sitecore.Events;
using Sitecore.Pipelines.LoggedIn;
using Sitecore.Publishing;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;

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
            var channelConfigs =
                _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Events.UserCreatedEventGuid));
            if (!channelConfigs.Any())
                return;

            var user = Event.ExtractParameter(args, 0) as MembershipUser;
            if (user == null) return;
            foreach (var channelConfig in channelConfigs)
            {
                _message.Text = $"User {user.UserName} was created.";
                _message.Channel = channelConfig.ChannelName;
                //TODO: populate the rest of the message
                _service.PublishMessage(_message);
            }
        }

        public void OnUserDeleted(object sender, EventArgs args)
        {
            var channelConfigs =
                _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Events.UserDeletedEventGuid));
            if (!channelConfigs.Any())
                return;
            var user = Event.ExtractParameter(args, 0) as MembershipUser;
            if (user == null) return;
            
            foreach (var channelConfig in channelConfigs)
            {
                _message.Text = $"User {user.UserName} was deleted.";
                _message.Channel = channelConfig.ChannelName;
                //TODO: populate the rest of the message
                _service.PublishMessage(_message);
            }
        }

        public void OnRoleCreated(object sender, EventArgs args)
        {
            var channelConfigs =
                _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Events.UserCreatedEventGuid));
            if (!channelConfigs.Any())
                return;

            var role = Event.ExtractParameter(args, 0) as string;
            if (role == null) return;
            foreach (var channelConfig in channelConfigs)
            {
                _message.Text = $"Role {role} was created.";
                _message.Channel = channelConfig.ChannelName;
                //TODO: populate the rest of the message
                _service.PublishMessage(_message);
            }
        }

        public void OnRoleDeleted(object sender, EventArgs args)
        {
            var channelConfigs =
                _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Events.UserDeletedEventGuid));
            if (!channelConfigs.Any())
                return;
            var role = Event.ExtractParameter(args, 0) as string;
            if (role == null) return;

            foreach (var channelConfig in channelConfigs)
            {
                _message.Text = $"Role {role} was deleted.";
                _message.Channel = channelConfig.ChannelName;
                //TODO: populate the rest of the message
                _service.PublishMessage(_message);
            }
        }

        #endregion


    }
}