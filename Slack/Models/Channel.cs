using Sitecore.Data;
using Sitecore.Data.Items;

namespace Slack
{
    public class Channel
    {
        #region Fields and Properties

        public const string TemplateIdString = "0127cf54-20a6-4df2-9a5d-95a84e209c22";
        public const string TemplateNameStatic = "Channel";
        public static readonly ID TemplateId = new ID(TemplateIdString);
        public static readonly ID Channel_NameFieldId = new ID("e8dac703-95e6-4cac-85ec-efe4c9f6438c");
        public static readonly ID DescriptionFieldId = new ID("668e7112-b7a9-4bed-93c2-9421aa77b5e8");
        public string Channel_Name { get; set; }
        public string Description { get; set; }

        #endregion

        #region Contructors

        public Channel(Item item)
        {
            Channel_Name = item.Fields[Channel_NameFieldId].Value;
            Description = item.Fields[DescriptionFieldId].Value;
        }

        #endregion
    }
}