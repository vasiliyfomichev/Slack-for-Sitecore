#region

using System;
using System.Linq;
using Sitecore.Events;
using Sitecore.Security.Accounts;
using Sitecore.Social.Client.Api.EventArgs;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;

#endregion

namespace Slack.Events
{
    // events don't fire for login/logout
    public class Social
    {
        #region Fields

        private readonly ISlackMessage _message;
        private readonly ISlackService _service;

        #endregion

        #region Constructors

        public Social()
        {
            _message = new SlackMessage();
            _service = new SlackService();
        }

        public Social(ISlackService service, ISlackMessage message)
        {
            _message = message;
            _service = service;
        }

        #endregion

        #region Methods

        public void OnUserCreated(object sender, EventArgs args)
        {
            //var channelConfigs =
            //    _service.GetApplicableSlackChannelConfigs(new Guid(Constants.EventIds.SocialUserCreatedEventGuid));
            //if (!channelConfigs.Any())
            //    return;

            //var user = Event.ExtractParameter(args, 0) as User;
            //if (user == null) return;
            //foreach (var channelConfig in channelConfigs)
            //{
            //    _message.Text = $"Social account {user.LocalName} has been created.";
            //    _message.Channel = channelConfig.ChannelName;
            //    //TODO: populate the rest of the message
            //    _service.PublishMessage(_message);
            //}
        }

        public void OnUserLoggedIn(object sender, EventArgs args)
        {
            //var channelConfigs =
            //    _service.GetApplicableSlackChannelConfigs(new Guid(Constants.EventIds.SocialUserLoggedInEventGuid));
            //if (!channelConfigs.Any())
            //    return;
            //var loggedInEvent = Event.ExtractParameter(args, 0) as SocialNetworkUserLoggedInEventArgs;
            //if (loggedInEvent == null) return;


            //foreach (var channelConfig in channelConfigs)
            //{
            //    _message.Text = $"Social {loggedInEvent.NetworkName} account {loggedInEvent.UserName} has logged in.";
            //    _message.Channel = channelConfig.ChannelName;
            //    //TODO: populate the rest of the message
            //    _service.PublishMessage(_message);
            //}
        }

        public void OnUserProfileAttached(object sender, EventArgs args)
        {
            //var channelConfigs =
            //    _service.GetApplicableSlackChannelConfigs(new Guid(Constants.EventIds.SocialProfileAttachedEventGuid));
            //if (!channelConfigs.Any())
            //    return;
            //var profileAttachedEvent = Event.ExtractParameter(args, 0) as SocialProfileAttachedEventArgs;
            //if (profileAttachedEvent == null) return;


            //foreach (var channelConfig in channelConfigs)
            //{
            //    _message.Text =
            //        $"Social {profileAttachedEvent.NetworkName} account {profileAttachedEvent.UserName} has been attached to profile.";
            //    _message.Channel = channelConfig.ChannelName;
            //    //TODO: populate the rest of the message
            //    _service.PublishMessage(_message);
            //}
        }

        #endregion
    }
}