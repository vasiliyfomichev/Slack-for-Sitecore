using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Events;
using Sitecore.Publishing;
using Slack.Contracts;
using Slack.Models;
using Slack.Services;

namespace Slack.Events
{
    public class Publish
    {

        #region Fields

        private readonly ISlackMessage _message;
        private readonly ISlackService _service;

        #endregion

        #region Constructors

        public Publish()
        {
           _message = new SlackMessage();
            _service = new SlackService(); 
        }

        public Publish(ISlackService service, ISlackMessage message)
        {
            _message = message;
            _service = service;
        }

        #endregion

        #region Methods

        public void OnPublishEnd(object sender, EventArgs args)
        {
            var publisher = Event.ExtractParameter(args, 0) as Publisher;

            // populate message
            _service.PublishMessage(_message);
        }

        #endregion

    }
}