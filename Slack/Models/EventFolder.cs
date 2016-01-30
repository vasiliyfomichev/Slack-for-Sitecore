using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Slack
{
    public partial class Event_Folder
    {
        [SitecoreChildren]
        public virtual IEnumerable<Event> Events { get; set; }
    }
}