using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Slack.Models
{
    public class Publication
    {
        #region Properties
        
        public static readonly ID TemplateId = new ID(Constants.Publication.TemplateIdString);
        public ID Id { get; set; }
        public Item Item { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public ID[] Channels { get; set; }
        public ID[] Events { get; set; }
        public string Message { get; set; }
        public ID TeamContext { get; set; }

        #endregion

        #region Contructors

        public Publication(Item item)
        {
            Item = item;
            Id = item.ID;
            Name = item.Fields[Constants.Publication.NameFieldId].Value;
            Description = item.Fields[Constants.Publication.DescriptionFieldId].Value;
            Channels = ((MultilistField) item.Fields[Constants.Publication.ChannelsFieldId]).TargetIDs;
            Events = ((MultilistField) item.Fields[Constants.Publication.EventsFieldId]).TargetIDs;
            Message = item.Fields[Constants.Publication.MessageFieldId].Value;
            TeamContext = ((LookupField) item.Fields[Constants.Publication.TeamContextFieldId]).TargetID;
        }

        #endregion

        #region Methods

        public IList<Channel> GetChannels()
        {
            var list = new List<Channel>();

            if (Item == null)
                return list;

            var channelItems = ((MultilistField) Item.Fields[Constants.Publication.ChannelsFieldId]).GetItems();

            foreach (var channel in channelItems)
            {
                list.Add(new Channel(channel));
            }

            return list;
        }

        public TeamContext GetTeamContext()
        {
            if (Item == null)
                return null;

            return new TeamContext(((LookupField) Item.Fields[Constants.Publication.TeamContextFieldId]).TargetItem);
        }

        #endregion
    }
}