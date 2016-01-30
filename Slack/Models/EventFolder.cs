using Sitecore.Data;
using Sitecore.Data.Items;

namespace Slack.Models
{
    public class EventFolder
    {
        #region Fields and Properties
        
        public static readonly ID TemplateId = new ID(Constants.EventFolder.TemplateIdString);
        public ID Id { get; set; }
        public Item Item { get; set; }

        #endregion

        #region Contructors

        public EventFolder(Item item)
        {
            Item = item;
            Id = item.ID;
        }

        #endregion
    }
}