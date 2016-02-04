using Sitecore.Data;

namespace Slack
{
    public class Constants
    {
        #region Template Constants

        public struct Channel
        {
            public const string TemplateIdString = "0127cf54-20a6-4df2-9a5d-95a84e209c22";
            public const string TemplateNameStatic = "Channel";
            public static readonly ID ChannelNameFieldId = new ID("e8dac703-95e6-4cac-85ec-efe4c9f6438c");
            public static readonly ID DescriptionFieldId = new ID("668e7112-b7a9-4bed-93c2-9421aa77b5e8");
        }

        public struct Event
        {
            public const string TemplateIdString = "e8a6891d-ce13-4e9a-a002-d98fee6dec96";
            public const string TemplateNameStatic = "Event";
            public static readonly ID DescriptionFieldId = new ID("3c5a56da-ac04-48e2-b465-b0b6fc867caf");
            public static readonly ID NameFieldId = new ID("f7ec9e45-42fd-4d18-a259-3b8013cf298b");
        }

        public struct EventFolder
        {
            public const string InstanceId = "89B26A3C-1C1A-47C4-895F-534DB019BE5F";
            public const string TemplateIdString = "2BFC1077-8359-401F-84D4-5B34D3CF2889";
            public const string TemplateNameStatic = "Event Folder";
        }

        public struct Publication
        {
            public static readonly ID DescriptionFieldId = new ID("9432b5e6-1ddb-41e7-b4d3-5fcf9b63f6bd");
            public static readonly ID NameFieldId = new ID("ad560039-1bab-4136-bb25-597e5c706c39");
            public static readonly ID ChannelsFieldId = new ID("99ab54d0-2d15-4654-84c4-3aa806e5dc7b");
            public static readonly ID EventsFieldId = new ID("dbb566a8-2404-4fea-95d3-3ab7f91b3c49");
            public static readonly ID MessageFieldId = new ID("013a8d98-6aa7-4bd9-80b4-4558ca34d563");
            public static readonly ID TeamContextFieldId = new ID("4ec68282-940e-4996-8e5d-05ceae67f009");
            public const string TemplateIdString = "e8bd1697-9a84-4d18-91d1-4fc9f8594b6e";
            public const string TemplateNameStatic = "Publication";
        }

        public struct PublicationFolder
        {
            public const string InstanceId = "4160247a-5a0a-45e1-9034-8c329fb4e78f";
            public const string TemplateIdString = "dc193d8e-2850-4bd9-aba8-f4afe43cfe7e";
            public const string TemplateNameStatic = "Publication Folder";
        }

        public struct TeamContext
        {
            public const string TemplateIdString = "457d4151-335d-4828-921f-a7e1b0a722e1";
            public const string TemplateNameStatic = "Team Context";
            public static readonly ID TokenFieldId = new ID("9c06739f-1865-472b-9c65-60da4a83927a");
            public static readonly ID UsernameFieldId = new ID("dd3dfde6-4199-4f94-a76e-14642f98c5de");
        }

        #endregion

        #region Nested Types

        /// <summary>
        /// Event ids for events defined under /sitecore/system/modules/slack/events
        /// </summary>
        public struct EventIds
        {
            public const string IndexingEnd = "{B96C1386-7A3F-4CBE-A710-6E3006380809}";
            public const string OnIndexingStart = "{9C110525-9753-419C-99EC-D201AD6C5AD1}";
            public const string EventsFolder = "{89B26A3C-1C1A-47C4-895F-534DB019BE5F}";
            public const string OnItemCreated = "{43F7F225-8C98-44B1-89BD-29B6EBDF2483}";
            public const string OnItemDeleted = "{C4F71B0F-951C-4E35-AE0E-E7D63FBE4311}";
            public const string OnItemMoved = "{C79152B0-D6D4-4A34-94C0-5C6325F63580}";
            public const string PublishFailedEvent = "{6A557224-F0A4-4AF9-9B35-73F3870B1BF0}";
            public const string PublishBeginEvent = "{7ABE0BA7-0583-4B56-8835-9C2656715C00}";
            public const string PublishEndEvent = "{727FB28B-0536-44C3-9210-F04A437FFB58}";
            public const string OnUserCreated = "{71A5B817-0C4D-4951-B52D-7095DA2D5004}";
            public const string OnUserDeleted = "{588A694A-E929-4C93-8CE8-DC19E1810954}";
            public const string OnRoleCreated = "{4E813827-3501-454A-B2DB-D60A367DE236}";
            public const string OnRoleDeleted = "{5BE8F4B1-532A-44BD-BE6E-8EE22031DCFE}";
            public const string OnPublishBegin = "{F089F137-287F-4401-B739-58C6388C8F5C}";
            public const string OnPublishEnd = "{A3912A05-DCFF-4AA4-AC85-C723B1C44FFE}";
            public const string OnPackageInstallStart = "{D58F4029-FBB7-462D-880F-D4A87439745D}";
            public const string OnPackageInstallEnd = "{39DEEEA9-0CED-461D-8134-1B5A145E84F6}";
            public const string SocialUserCreatedEventGuid = "{}";
            public const string SocialProfileAttachedEventGuid = "{}";
            public const string SocialUserLoggedInEventGuid = "{}";
        }

        /// <summary>
        /// Event ids for events triggered by pipelines defined under /sitecore/system/modules/slack/events
        /// </summary>
        public struct PipelineEventIds
        {
            public const string ApplicationInitialization = "{80B4E1C1-6C99-47CD-860E-C7B4DD566B31}";
            public const string ApplicationShutdown = "{5BCF735A-96DF-4BC2-84D9-3EE13B8ED822}";
            public const string ApplicationMvcException = "{11C7E972-C963-4247-84ED-C1F381DEAE78}";
            public const string PageEvent = "{B9C3C15B-7627-461C-AB4F-4B876CB4D89B}";
            public const string CampaignTriggered = "{2E4D6E5F-CEBA-4649-B8E4-99337DC75C6D}";
            public const string ListDeletion = "{8DD410DE-1E2D-4579-A3CF-CEBE6D05941D}";
            public const string ListCreation = "{FD11D6EC-4EA6-4E6C-8F94-6E847A1D8F95}";
            public const string PageTestStarted = "{9984E971-5DB0-4B25-97AA-453C97627CC8}";
            public const string TestStarted = "{EDCFCAEF-E8EA-49F8-A651-7651E7920072}";
            public const string TestStopped = "{7D10E748-160B-4E3E-BD2F-4ECE3F4A1754}";
        }

        /// <summary>
        /// Event ids for events triggered by pocessors defined under /sitecore/system/modules/slack/events
        /// </summary>
        public struct PocessorEventIds
        {
            public const string UserLoggedIn = "{13AF25DC-E30E-4BF2-A18C-28480B40AAA3}";
            public const string UserLogOut = "{1FF0B819-4656-4916-97CC-037E235A704E}";
        }

        #endregion
    }
}