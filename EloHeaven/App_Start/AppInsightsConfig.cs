using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Azure;

namespace EloHeaven
{
    public static class AppInsightsConfig
    {
        public static void Register(HttpConfiguration config)
        {
            Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration.Active.InstrumentationKey = CloudConfigurationManager.GetSetting("InstrumentationKey");
        }
    }
}