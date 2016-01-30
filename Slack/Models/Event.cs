using Sitecore.Data;
using Sitecore.Data.Items;

namespace Slack
{
    public class Event
    {
        public const string TemplateIdString = "e8a6891d-ce13-4e9a-a002-d98fee6dec96";
        public static readonly ID TemplateId = new ID(TemplateIdString);
        public const string TemplateNameStatic = "Event";

        public ID Id { get; set; }
        public Item Item { get; set; }
        public static readonly ID DescriptionFieldId = new ID("3c5a56da-ac04-48e2-b465-b0b6fc867caf");
        public string Description { get; set; }

        public string Name { get; set; }

        public static readonly ID NameFieldId = new ID("f7ec9e45-42fd-4d18-a259-3b8013cf298b");

        public Event(Item item)
        {
            Item = item;
            Id = item.ID;
            Name = item.Fields[NameFieldId].Value;
            Description = item.Fields[DescriptionFieldId].Value;
        }

    }

}