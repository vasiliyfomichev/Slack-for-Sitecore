using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Slack
{
    public class Constants
    {
        public struct Events
        {
            public const string PublishEndEventGuid = "{}";
            public const string PublishBeginEventGuid = "{}";
            public const string LoggedInEventGuid = "{}";
            public const string LoggedOutEventGuid = "{}";
            public const string UserCreatedEventGuid = "{}";
            public const string UserDeletedEventGuid = "{}";
            public const string PackageInstallStartedEventGuid = "{}";
            public const string PackageInstallEndedEventGuid = "{}";
        }
    }
}