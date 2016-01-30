using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Slack
{
    public class Publication_Folder
    {
        #region Fields and Properties

        public const string InstanceId = "4160247a-5a0a-45e1-9034-8c329fb4e78f";
        public const string TemplateIdString = "dc193d8e-2850-4bd9-aba8-f4afe43cfe7e";
        public const string TemplateNameStatic = "Publication Folder";
        public static readonly ID TemplateId = new ID(TemplateIdString);

        public ID Id { get; set; }
        public Item Item { get; set; }

        #endregion

        #region Contructors

        public Publication_Folder(Item item)
        {
            Item = item;
            Id = item.ID;
        }

        #endregion

        #region Methods

        public IList<Publication> GetPublications()
        {
            var list = new List<Publication>();

            if (Item == null)
                return list;

            foreach (Item child in Item.Children)
            {
                list.Add(new Publication(child));
            }
            return list;
        }

        #endregion
    }
}