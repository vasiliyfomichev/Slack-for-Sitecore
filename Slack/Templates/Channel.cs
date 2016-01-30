using Sitecore.Data;

namespace Slack.Templates
{
    public struct Channel
    {
        public static readonly ID ID = new ID("{0127CF54-20A6-4DF2-9A5D-95A84E209C22}");

        public struct Fields
        {
            public static readonly ID Name = new ID("{E8DAC703-95E6-4CAC-85EC-EFE4C9F6438C}");
            public static readonly ID Description = new ID("{668E7112-B7A9-4BED-93C2-9421AA77B5E8}");

            public static readonly ID SlackTeamName = new ID("{D88F5409-1F1D-46A2-8AE9-3957978B3091}");
            public static readonly ID AdminUser = new ID("{9C2DAC7D-FAEA-4E96-A794-54ECE702635B}");
            public static readonly ID AdminPassword = new ID("{F521ABDB-CA5C-4DD7-835C-8B83C59372BF}");
        }
    }
}