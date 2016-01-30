#region

using System;
using System.Linq;
using Sitecore.Mvc.Pipelines.MvcEvents.Exception;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;

#endregion

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
            if (args == null) return;
            var publications = _service.GetApplicablePublications(new Guid(Constants.Pipelines.ApplicationMvcExceptionEventId));
            if (!publications.Any())
                return;
            var message = $"MVC error occured on item {args.PageContext.Item.Paths.Path}. \n" +
                          $"{args.Message} \n";
            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = message;
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message);
                }
            }
        }
    }
}