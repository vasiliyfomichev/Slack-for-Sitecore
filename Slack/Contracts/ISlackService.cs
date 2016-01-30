using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slack.Contracts
{
    public interface ISlackService
    {
        void PublishMessage(ISlackMessage message);

        IList<ISlackChannelConfig> GetApplicableSlackChannelConfigs(Guid eventId);
    }
}
