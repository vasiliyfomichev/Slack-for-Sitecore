using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Slack.Tests.Configuration;
using SlackConnector;
using SlackConnector.Models;

namespace Slack.Tests
{
    [TestFixture]
    public class SlackConnectorTests
    {
        private Config _config;

        [SetUp]
        public void Setup()
        {
            _config = new ConfigReader().GetConfig();
        }

        [Test]
        public void should_connect_and_stuff()
        {
            // given
            var slackConnector = new SlackConnector.SlackConnector();

            // when
            var connection = slackConnector.Connect(_config.Slack.ApiToken);
            connection.OnDisconnect += SlackConnector_OnDisconnect;
            connection.OnMessageReceived += SlackConnectorOnOnMessageReceived;

            // then
            Assert.That(connection.IsConnected, Is.True);
        }

        [Test]
        public void should_say_something_on_channel()
        {
            // given

            var slackConnector = new SlackConnector.SlackConnector();
            var connection = slackConnector.Connect(_config.Slack.ApiToken).Result;
            var message = new BotMessage
            {
                Text = "Test text from SlackConnectorTests :)",
                ChatHub = connection.ConnectedChannels().First(x => x.Name.Equals("#general", StringComparison.InvariantCultureIgnoreCase))
            };

            // when
            connection.Say(message).Wait();

            // then
        }

        private void SlackConnector_OnDisconnect()
        {

        }

        private Task SlackConnectorOnOnMessageReceived(SlackMessage message)
        {
            return new Task(() => { });
        }
    }
}