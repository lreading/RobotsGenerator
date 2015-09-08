using System;
using System.Collections.Generic;

namespace RobotsTxtGenerator
{
    public class RobotsItem
    {
        public RobotsItem(String Url, AccessTypeEnum Accesstype, UserAgentEnum Useragent = UserAgentEnum.All)
        {
            this.AccessType = Accesstype;
            this.UserAgent = Useragent;
            this.RelativeURL = Url;
        } // end constructor

        public AccessTypeEnum AccessType { get; set; }
        public UserAgentEnum UserAgent { get; set; }
        public String RelativeURL { get; set; }

        public enum AccessTypeEnum
        {
            Disallow,
            Allow
        } // end access type

        public enum UserAgentEnum
        {
            All,
            GoogleBot,
            Slurp,
            msnbot
        }
    } // end class robots item
} // end namespace