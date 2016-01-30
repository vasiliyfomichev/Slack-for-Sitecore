using System;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Slack.Tests.Configuration
{
    public class ConfigReader : IConfigReader
    {
        private Config Current { get; set; }

        public Config GetConfig()
        {
            if (Current == null)
            {
                //HACK: for some reason resharper is makeing the Environment.CurrentDirectory wrong so hard coding it for now
                //string fileName = Path.Combine(Environment.CurrentDirectory, "configuration", "config.json");
                string fileName = Path.Combine(@"C:\Projects\Sitecore-Hackathon-2016\Slack.Tests\bin\Debug\", "configuration", "config.json");
                if (!File.Exists(fileName))
                {
                    Assert.Inconclusive("Unable to load config file from: " + fileName);
                }

                string json = File.ReadAllText(fileName);
                if (string.IsNullOrEmpty(json))
                {
                    Assert.Inconclusive("Unable to load config");
                }

                Current = JsonConvert.DeserializeObject<Config>(json);
            }

            return Current;
        }
    }
}