using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Slack
{
    public partial class Publication_Folder
    {
        [SitecoreChildren]
        public virtual IEnumerable<Publication> Publications { get; set; }
    }
}