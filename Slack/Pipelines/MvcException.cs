using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Mvc.Pipelines.MvcEvents.Exception;
using Sitecore.Pipelines;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;

namespace Slack.Pipelines
{
    public class MvcException
    {
        #region Fields

        private readonly ISlackMessage _message;
        private readonly ISlackService _service;

        #endregion

        #region Constructors

        public MvcException()
        {
            _message = new SlackMessage();
            _service = new SlackService();
        }

        public MvcException(ISlackService service, ISlackMessage message)
        {
            _message = message;
            _service = service;
        }

        #endregion

        public void Process(ExceptionArgs args)
        {
            var channelConfigs =
                   _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Pipelines.ApplicationMvcExceptionEventId));
            if (!channelConfigs.Any())
                return;

            var message = $"MVC error occured on item {args.PageContext.Item.Paths.Path}. \n" +
                                $"{args.Message} \n";
            foreach (var channelConfig in channelConfigs)
            {
                _message.Text = message;
                _message.Channel = channelConfig.ChannelName;
                //TODO: populate the rest of the message
                _service.PublishMessage(_message);
            }
        }
    }
}