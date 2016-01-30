using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slack.Contracts
{
    public interface ISlackChannelConfig
    {
        string IconUrl { get; set; }
        string ChannelName { get; set; }
    }
}
