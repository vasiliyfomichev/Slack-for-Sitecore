using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slack.Contracts
{
    internal interface ISlackRepository
    {
        void PublishMessage(ISlackMessage message);
    }
}
