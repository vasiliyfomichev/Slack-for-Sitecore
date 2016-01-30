#region

using System;
using System.Linq;
using Sitecore.Pipelines;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;

#endregion

namespace Slack.Pipelines
{
    public class Shutdown
    {
        #region Fields

        private readonly ISlackMessage _message;
        private readonly ISlackService _service;

        #endregion

        #region Constructors

        public Shutdown()
        {
            _message = new SlackMessage();
            _service = new SlackService();
        }

        public Shutdown(ISlackService service, ISlackMessage message)
        {
            _message = message;
            _service = service;
        }

        #endregion

        public void Process(PipelineArgs args)
        {
            //if (args == null) return;
            //var channelConfigs =
            //    _service.GetApplicableSlackChannelConfigs(new Guid(Constants.Pipelines.ApplicationShutdownEventId));
            //if (!channelConfigs.Any())
            //    return;

            //foreach (var channelConfig in channelConfigs)
            //{
            //    _message.Text = "Sitecore instance is shutting down.";
            //    _message.Channel = channelConfig.ChannelName;
            //    //TODO: populate the rest of the message
            //    _service.PublishMessage(_message);
            //}
        }
    }
}