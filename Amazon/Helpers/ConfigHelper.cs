using System;
using System.Configuration;
using NUnit.Framework;

namespace Amazon.Helpers
{
    public class ConfigHelper
    {
        public static string WEB_URL { get; }

        static ConfigHelper()
        {
            WEB_URL = ReadConfiguration("url");
        }

        private static string ReadConfiguration(string key)
        {
            string value;
            
            value = TestContext.Parameters[key];

            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Reading configuration for key: " + key + " from .config");
                value = ConfigurationManager.AppSettings.Get(key);
            }
            return value;
        }
    }
}