using Sitecore.Data;
using Sitecore.Data.Items;

namespace Slack.Models
{
    public class Channel
    {
        #region Fields and Properties
        
        public static readonly ID TemplateId = new ID(Constants.Channel.TemplateIdString);
        public string ChannelName { get; set; }
        public string Description { get; set; }

        #endregion

        #region Contructors

        public Channel(Item item)
        {
            ChannelName = item.Fields[Constants.Channel.ChannelNameFieldId].Value;
            Description = item.Fields[Constants.Channel.DescriptionFieldId].Value;
        }

        #endregion
    }
}