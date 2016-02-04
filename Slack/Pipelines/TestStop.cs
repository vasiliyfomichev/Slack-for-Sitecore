#region

using System;
using System.Linq;
using Sitecore.ContentTesting.Pipelines.StopTest;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;

#endregion

namespace Slack.Pipelines
{
    public class TestStop
    {
        #region Fields

        private readonly ISlackMessage _message;
        private readonly ISlackService _service;

        #endregion

        #region Constructors

        public TestStop()
        {
            _message = new SlackMessage();
            _service = new SlackService();
        }

        public TestStop(ISlackService service, ISlackMessage message)
        {
            _message = message;
            _service = service;
        }

        #endregion

        public void Process(StopTestArgs args)
        {
            if (args == null) return;
            var publications = _service.GetApplicablePublications(new Guid(Constants.PipelineEventIds.TestStopped));
            if (!publications.Any())
                return;
            var message =
                    $"Test stopped for {args.Configuration.ContentItem}. The winner is {args.WinnerVersion.Paths.Path}.";
            foreach (var publication in publications)
            {
                foreach (var channel in publication.GetChannels())
                {
                    _message.Text = message;
                    _message.UpdateChannelInfo(channel, publication);
                    _service.PublishMessage(_message, true);
                }
            }
        }
    }
}