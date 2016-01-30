using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Slack.Models
{
    public class Publication_Folder
    {
        #region Fields and Properties

        public static readonly ID TemplateId = new ID(Constants.PublicationFolder.TemplateIdString);

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