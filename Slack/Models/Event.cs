using Sitecore.Data;
using Sitecore.Data.Items;

namespace Slack.Models
{
    public class Event
    {
        #region Properties and Fields

        public static readonly ID TemplateId = new ID(Constants.Event.TemplateIdString);
        public ID Id { get; set; }
        public Item Item { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        #endregion

        public Event(Item item)
        {
            Item = item;
            Id = item.ID;
            Name = item.Fields[Constants.Event.NameFieldId].Value;
            Description = item.Fields[Constants.Event.DescriptionFieldId].Value;
        }

    }

}