namespace Slack.Contracts
{
    /// <summary>
    /// Message object to be posted to Slack Web API
    /// https://api.slack.com/methods/chat.postMessage
    /// </summary>
    public interface ISlackMessage
    {
        string Token { get; set; }
        string Channel { get; set; }
        string Text { get; set; }
        string Username { get; set; }
        bool AsUser { get; set; }
        string IconUrl { get; set; }
    }
}
