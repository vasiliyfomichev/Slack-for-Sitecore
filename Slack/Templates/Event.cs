using Sitecore.Data;

namespace Slack.Templates
{
    public struct Event
    {
        public static readonly ID ID = new ID("{E8A6891D-CE13-4E9A-A002-D98FEE6DEC96}");

        public struct Fields
        {
            public static readonly ID Name = new ID("{F7EC9E45-42FD-4D18-A259-3B8013CF298B}");
            public static readonly ID Description = new ID("{3C5A56DA-AC04-48E2-B465-B0B6FC867CAF}");

            public static readonly ID TriggerSource = new ID("{0FB4B4CC-EF50-4358-BB23-AD416F1EF2A0}");
        }
    }
}