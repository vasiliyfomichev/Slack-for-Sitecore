using Sitecore.Data;
using Sitecore.Data.Items;

namespace Slack.Models
{
    public class TeamContext
    {
        #region Fields and Properties

        public static readonly ID TemplateId = new ID(Constants.TeamContext.TemplateIdString);
        public string Token { get; set; }
        public string Username { get; set; }

        #endregion

        #region Contructors

        public TeamContext(Item item)
        {
            Token = item?.Fields[Constants.TeamContext.TokenFieldId]?.Value;
            Username = item?.Fields[Constants.TeamContext.UsernameFieldId]?.Value;
        }

        #endregion
    }
}