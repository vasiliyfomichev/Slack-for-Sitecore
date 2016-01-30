namespace Slack
{
    public class Constants
    {
        #region Nested Types

        public struct Events
        {
            public const string IndexingEndID = "{B96C1386-7A3F-4CBE-A710-6E3006380809}";
            public const string OnIndexingStart = "{9C110525-9753-419C-99EC-D201AD6C5AD1}";
            public const string EventsFolder = "{89B26A3C-1C1A-47C4-895F-534DB019BE5F}";

            public const string OnItemCreated = "{43F7F225-8C98-44B1-89BD-29B6EBDF2483}";
            public const string OnItemDeleted = "{C4F71B0F-951C-4E35-AE0E-E7D63FBE4311}";
            public const string OnItemMoved = "{C79152B0-D6D4-4A34-94C0-5C6325F63580}";
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
            public const string OnPackageInstallStart = "{D58F4029-FBB7-462D-880F-D4A87439745D}";
            public const string OnPackageInstallEnd = "{39DEEEA9-0CED-461D-8134-1B5A145E84F6}";
            public const string SocialUserCreatedEventGuid = "{}";
            public const string SocialProfileAttachedEventGuid = "{}";
            public const string SocialUserLoggedInEventGuid = "{}";
        }

        public struct Pipelines
        {
            public const string ApplicationInitializationEventId = "{80B4E1C1-6C99-47CD-860E-C7B4DD566B31}";
            public const string ApplicationShutdownEventId = "{5BCF735A-96DF-4BC2-84D9-3EE13B8ED822}";
            public const string ApplicationMvcExceptionEventId = "{11C7E972-C963-4247-84ED-C1F381DEAE78}";
            public const string PageEventEventId = "{B9C3C15B-7627-461C-AB4F-4B876CB4D89B}";
            public const string CampaignTriggeredEventId = "{2E4D6E5F-CEBA-4649-B8E4-99337DC75C6D}";
            public const string ListDeletionEventId = "{8DD410DE-1E2D-4579-A3CF-CEBE6D05941D}";
            public const string ListCreationEventId = "{FD11D6EC-4EA6-4E6C-8F94-6E847A1D8F95}";
            public const string PageTestStartedEventId = "{9984E971-5DB0-4B25-97AA-453C97627CC8}";
            public const string TestStartedEventId = "{EDCFCAEF-E8EA-49F8-A651-7651E7920072}";
            public const string TestStoppedEventId = "{7D10E748-160B-4E3E-BD2F-4ECE3F4A1754}";
        }

        #endregion
    }
}