using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Slack
{
    public class Publication
    {
        public const string TemplateIdString = "e8bd1697-9a84-4d18-91d1-4fc9f8594b6e";
        public static readonly ID TemplateId = new ID(TemplateIdString);
        public const string TemplateNameStatic = "Publication";

        public ID Id { get; set; }
        public Item Item { get; set; }
        public static readonly ID DescriptionFieldId = new ID("9432b5e6-1ddb-41e7-b4d3-5fcf9b63f6bd");
        public string Description { get; set; }

        public string Name { get; set; }

        public static readonly ID NameFieldId = new ID("ad560039-1bab-4136-bb25-597e5c706c39");

        public ID[] Channels { get; set; }

        public static readonly ID ChannelsFieldId = new ID("99ab54d0-2d15-4654-84c4-3aa806e5dc7b");

        public ID[] Events { get; set; }

        public static readonly ID EventsFieldId = new ID("dbb566a8-2404-4fea-95d3-3ab7f91b3c49");

        public string Message { get; set; }

        public static readonly ID MessageFieldId = new ID("013a8d98-6aa7-4bd9-80b4-4558ca34d563");

        public ID TeamContext { get; set; }

        public static readonly ID TeamContextFieldId = new ID("4ec68282-940e-4996-8e5d-05ceae67f009");

        public Publication(Item item)
        {
            Item = item;
            Id = item.ID;
            Name = item.Fields[NameFieldId].Value;
            Description = item.Fields[DescriptionFieldId].Value;
            Channels = ((Sitecore.Data.Fields.MultilistField) item.Fields[ChannelsFieldId]).TargetIDs;
            Events = ((Sitecore.Data.Fields.MultilistField) item.Fields[EventsFieldId]).TargetIDs;
            Message = item.Fields[MessageFieldId].Value;
            TeamContext = ((Sitecore.Data.Fields.LookupField) item.Fields[TeamContextFieldId]).TargetID;
        }

        public TeamContext GetTeamContext()
        {
            if (Item == null)
                return null;

            return new TeamContext(((Sitecore.Data.Fields.LookupField)Item.Fields[TeamContextFieldId]).TargetItem);
        }

        public IList<Channel> GetChannels()
        {
            var list = new List<Channel>();

            if (Item == null)
                return list;

            var channelItems = ((Sitecore.Data.Fields.MultilistField) Item.Fields[ChannelsFieldId]).GetItems();

            foreach (Item channel in channelItems)
            {
                list.Add(new Channel(channel));
            }

            return list;
        }

    }
}