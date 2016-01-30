namespace Slack.Contracts
{
    public interface ISlackChannelConfig
    {
        string IconUrl { get; set; }
        string ChannelName { get; set; }
    }
}