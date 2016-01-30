using Sitecore.Data;
using Sitecore.Data.Items;

namespace Slack
{
    public class Event_Folder
    {
        #region Fields and Properties

        public const string InstanceId = "89B26A3C-1C1A-47C4-895F-534DB019BE5F";
        public const string TemplateIdString = "2BFC1077-8359-401F-84D4-5B34D3CF2889";
        public const string TemplateNameStatic = "Event Folder";
        public static readonly ID TemplateId = new ID(TemplateIdString);

        public ID Id { get; set; }
        public Item Item { get; set; }

        #endregion

        #region Contructors

        public Event_Folder(Item item)
        {
            Item = item;
            Id = item.ID;
        }

        #endregion
    }
}