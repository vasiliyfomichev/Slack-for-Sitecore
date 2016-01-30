using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Slack
{
    public class Constants
    {
        public struct Events
        {
            public const string IndexingEndID = "{B96C1386-7A3F-4CBE-A710-6E3006380809}";
            public const string IndexingBeginID = "{9C110525-9753-419C-99EC-D201AD6C5AD1}";

            public const string ItemCreatedID = "{9D997FF2-4A8F-4923-9256-9198540E692E}";
            public const string ItemDeletedID = "{10869EE4-663C-429E-B645-F7B0E2853008}";
            public const string ItemMovedID = "{62709B5D-EC90-4042-83E6-4B51C2546247}";
            public const string ItemSavedID = "{CC11DB70-40CB-4980-8298-236C09FAE0FA}";

            public const string LoginID = "{94507A41-470E-4B50-BF20-5C6C6A3C577E}";
            public const string Logout = "{61E43D90-4289-4080-A4FF-344378839F28}";

            public const string PackageInstallFinishedID = "{D57A5A9F-682F-49E8-997D-F2BA9DBADA54}";
            public const string PackageInstallStartedID = "{204769B1-59B8-4A7D-BE1A-FB7E94221580}";

            public const string PublishFailedID = "{6A557224-F0A4-4AF9-9B35-73F3870B1BF0}";
            public const string PublishBeginEventID = "{7ABE0BA7-0583-4B56-8835-9C2656715C00}";
            public const string PublishEndEventID = "{727FB28B-0536-44C3-9210-F04A437FFB58}";
        }

        public struct Channel
        {
            public const string ID = "{0127CF54-20A6-4DF2-9A5D-95A84E209C22}";

            public struct Fields
            {
                public const string Name = "{E8DAC703-95E6-4CAC-85EC-EFE4C9F6438C}";
                public const string Description = "{668E7112-B7A9-4BED-93C2-9421AA77B5E8}";

                public const string SlackTeamName = "{D88F5409-1F1D-46A2-8AE9-3957978B3091}";
                public const string AdminUser = "{9C2DAC7D-FAEA-4E96-A794-54ECE702635B}";
                public const string AdminPassword = "{F521ABDB-CA5C-4DD7-835C-8B83C59372BF}";
            }
        }

        public struct Event
        {
            public const string ID = "{E8A6891D-CE13-4E9A-A002-D98FEE6DEC96}";

            public struct Fields
            {
                public const string Name = "{F7EC9E45-42FD-4D18-A259-3B8013CF298B}";
                public const string Description = "{3C5A56DA-AC04-48E2-B465-B0B6FC867CAF}";

                public const string TriggerSource = "{0FB4B4CC-EF50-4358-BB23-AD416F1EF2A0}";
            }
        }

        public struct EventType
        {
            public const string ID = "{C63F7736-70D1-447C-8142-7D581C664CE1}";

            public struct Fields
            {
                public const string Name = "{FA66CE6A-17DA-483D-B707-03B2962ACC86}";
            }
        }

        public struct Publication
        {
            public const string ID = "{E8BD1697-9A84-4D18-91D1-4FC9F8594B6E}";

            public struct Fields
            {
                public const string Name = "{AD560039-1BAB-4136-BB25-597E5C706C39}";
                public const string Description = "{9432B5E6-1DDB-41E7-B4D3-5FCF9B63F6BD}";

                public const string Channels = "{99AB54D0-2D15-4654-84C4-3AA806E5DC7B}";
            }
        }
    }
}