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
            public const string UserCreatedEventGuid = "{}";
            public const string UserDeletedEventGuid = "{}";
            public const string IndexingEndID = "{B96C1386-7A3F-4CBE-A710-6E3006380809}";
            public const string IndexingBeginID = "{9C110525-9753-419C-99EC-D201AD6C5AD1}";
            public const string EventsFolder = "{89B26A3C-1C1A-47C4-895F-534DB019BE5F}";

            public const string ItemCreatedID = "{9D997FF2-4A8F-4923-9256-9198540E692E}";
            public const string ItemDeletedID = "{10869EE4-663C-429E-B645-F7B0E2853008}";
            public const string ItemMovedID = "{62709B5D-EC90-4042-83E6-4B51C2546247}";

            public const string LoggedInEventId = "{94507A41-470E-4B50-BF20-5C6C6A3C577E}";
            public const string LoggedOutEventId = "{61E43D90-4289-4080-A4FF-344378839F28}";

            public const string PackageInstallFinishedID = "{D57A5A9F-682F-49E8-997D-F2BA9DBADA54}";
            public const string PackageInstallStartedID = "{204769B1-59B8-4A7D-BE1A-FB7E94221580}";

            public const string PublishFailedEventId = "{6A557224-F0A4-4AF9-9B35-73F3870B1BF0}";
            public const string PublishBeginEventID = "{7ABE0BA7-0583-4B56-8835-9C2656715C00}";
            public const string PublishEndEventID = "{727FB28B-0536-44C3-9210-F04A437FFB58}";
            public const string OnUserCreated = "{71A5B817-0C4D-4951-B52D-7095DA2D5004}";
            public const string OnUserDeleted = "{588A694A-E929-4C93-8CE8-DC19E1810954}";
            public const string OnRoleCreated = "{4E813827-3501-454A-B2DB-D60A367DE236}";
            public const string OnRoleDeleted = "{5BE8F4B1-532A-44BD-BE6E-8EE22031DCFE}";
            public const string OnPublishBegin = "{F089F137-287F-4401-B739-58C6388C8F5C}";
            public const string OnPublishEnd = "{A3912A05-DCFF-4AA4-AC85-C723B1C44FFE}";
            public const string OnLoggedIn = "{13AF25DC-E30E-4BF2-A18C-28480B40AAA3}";
            public const string OnLoggedOut = "{1FF0B819-4656-4916-97CC-037E235A704E}";
            public const string PackageInstallStartedEventGuid = "{}";
            public const string PackageInstallEndedEventGuid = "{}";
            public const string SocialUserCreatedEventGuid = "{}";
            public const string SocialProfileAttachedEventGuid = "{}";
            public const string SocialUserLoggedInEventGuid = "{}";
        }

        public struct Pipelines
        {
            public const string ApplicationInitializationEventId = "";
            public const string ApplicationShutdownEventId = "";
            public const string ApplicationMvcExceptionEventId = "";
            public const string PageEventEventId = "";
            public const string CampaignTriggeredEventId = "";
            public const string ListDeletionEventId = "";
            public const string ListCreationEventId = "";
            public const string PageTestStartedEventId = "";
            public const string TestStartedEventId = "";
            public const string TestStoppedEventId = "";
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


        public struct Publication
        {
            public const string PublicationsFolder = "{4160247A-5A0A-45E1-9034-8C329FB4E78F}";
        }
    }
}