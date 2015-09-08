using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotsTxtGenerator
{
    public class RobotsGenerator : IRobotsGenerator
    {
        public String GenerateRobots(IEnumerable<RobotsItem> Items)
        {
            String RobotsTxt = String.Empty;

            // EXAMPLE:
            //      User-agent: *
            //      Disallow: /js/
            //      Allow: /something/
            IEnumerable<RobotsItem.UserAgentEnum> SelectedUserAgents = Items.Select(x => x.UserAgent).Distinct();
            foreach (RobotsItem.UserAgentEnum UserAgent in SelectedUserAgents)
            {
                IEnumerable<String> DisallowedSites = Items.Where(x => x.UserAgent == UserAgent && x.AccessType == RobotsItem.AccessTypeEnum.Disallow).Select(y => y.RelativeURL);
                IEnumerable<String> AllowedSites = Items.Where(x => x.UserAgent == UserAgent && x.AccessType == RobotsItem.AccessTypeEnum.Allow).Select(y => y.RelativeURL);
                RobotsTxt += String.Format("User-agent: {0}{1}", UserAgent == RobotsItem.UserAgentEnum.All ? "*" : UserAgent.ToString(), Environment.NewLine);
                foreach (String Url in DisallowedSites)
                {
                    RobotsTxt += String.Format("Disallow: {0}{1}", Url, Environment.NewLine);
                } // end loop
                RobotsTxt += Environment.NewLine;
                foreach (String Url in AllowedSites)
                {
                    RobotsTxt += String.Format("Allow: {0}{1}", Url, Environment.NewLine);
                } // end loop
                RobotsTxt += Environment.NewLine;
            } // end user agent loop

            return RobotsTxt;
        } // end generate robots
    } // end class RobotsGenerator
} // end namespace