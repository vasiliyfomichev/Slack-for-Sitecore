using Sitecore.Data;
using Sitecore.Data.Items;

namespace Slack
{
    public class TeamContext
    {
        #region Fields and Properties

        public const string TemplateIdString = "457d4151-335d-4828-921f-a7e1b0a722e1";
        public static readonly ID TemplateId = new ID(TemplateIdString);
        public const string TemplateNameStatic = "Team Context";
        public string Token { get; set; }
        public static readonly ID TokenFieldId = new ID("9c06739f-1865-472b-9c65-60da4a83927a");
        public string Username { get; set; }
        public static readonly ID UsernameFieldId = new ID("dd3dfde6-4199-4f94-a76e-14642f98c5de");

        #endregion

        #region Contructors

        public TeamContext(Item item)
        {
            Token = item.Fields[TokenFieldId].Value;
            Username = item.Fields[UsernameFieldId].Value;
        }

        #endregion
    }
}