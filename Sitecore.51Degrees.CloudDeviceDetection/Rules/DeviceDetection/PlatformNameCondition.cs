﻿using Sitecore.Diagnostics;
using Sitecore.FiftyOneDegrees.CloudDeviceDetection.Services;
using Sitecore.FiftyOneDegrees.CloudDeviceDetection.System.Wrappers;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;

namespace Sitecore.FiftyOneDegrees.CloudDeviceDetection.Rules.DeviceDetection
{
	public class PlatformNameCondition<T> : StringOperatorCondition<T> where T : RuleContext
    {
        public string PlatformName { get; set; }

        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull(ruleContext, "ruleContext");

			IHttpRequestWrapper httpRequestWrapper = new HttpContextWrapper().Request;
			if (httpRequestWrapper == null)
			{
				return false;
			}

			var browserCapabilitiesService = new BrowserCapabilitiesService(httpRequestWrapper);

            return Compare(browserCapabilitiesService.GetStringProperty("PlatformName"), PlatformName);
        }
    }
}
