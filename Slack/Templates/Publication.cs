using Sitecore.Data;

namespace Slack.Templates
{
    public struct Publication
    {
        public static readonly ID ID = new ID("{E8BD1697-9A84-4D18-91D1-4FC9F8594B6E}");

        public struct Fields
        {
            public static readonly ID Name = new ID("{AD560039-1BAB-4136-BB25-597E5C706C39}");
            public static readonly ID Description = new ID("{9432B5E6-1DDB-41E7-B4D3-5FCF9B63F6BD}");

            public static readonly ID Channels = new ID("{99AB54D0-2D15-4654-84C4-3AA806E5DC7B}");
        }
    }
}