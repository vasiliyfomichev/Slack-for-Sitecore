using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Slack
{
    public partial class Publication
    {
        [SitecoreField(TeamContextFieldName)]
        public virtual Team_Context TeamContextItem { get; set; }

        [SitecoreField(ChannelsFieldName)]
        public virtual IEnumerable<Channel> ChannelItems { get; set; }

        [SitecoreField(EventsFieldName)]
        public virtual IEnumerable<Event> EventItems { get; set; }

    }
}