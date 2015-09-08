using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RobotsTxtGenerator;
using System.Web.Mvc;

namespace BobotsTxtGenerator.MVC.BLL
{
    public class SEOMethods
    {
        /// <summary>
        /// Gets all of the robots items that will create our robots.txt file
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public List<RobotsItem> GetRobotsTXTItems(UrlHelper Url)
        {
            List<RobotsItem> AllRobotsItems = new List<RobotsItem>();

            // Get the pages we want to explicitly allow.
            AllRobotsItems.AddRange(GetAllowedRobotsTxtItems(Url));

            // Get the disallowed pages
            AllRobotsItems.AddRange(GetDisallowedItems(Url));

            // Get pages you only want Google to find
            AllRobotsItems.AddRange(GetGoogleOnlyPages(Url));

            return AllRobotsItems;
        } // end get robots txt items

        /// <summary>
        /// Gets a collection of robots items to be marked as allowed for all user agents.
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        private List<RobotsItem> GetAllowedRobotsTxtItems(UrlHelper Url)
        {
            List<RobotsItem> AllowedPages = new List<RobotsItem>();
            AllowedPages.Add(new RobotsItem(Url.Action("Index", "Home"), RobotsItem.AccessTypeEnum.Allow, RobotsItem.UserAgentEnum.All));
            AllowedPages.Add(new RobotsItem(Url.Action("About", "Home"), RobotsItem.AccessTypeEnum.Allow, RobotsItem.UserAgentEnum.All));
            AllowedPages.Add(new RobotsItem(Url.Action("Contact", "Home"), RobotsItem.AccessTypeEnum.Allow, RobotsItem.UserAgentEnum.All));

            //// If you had a blog and wanted to add all of your blog posts, you could do something like the following:
            //IEnumerable<Int32> PostIds = _db.Posts.Select(x => x.Id);
            //foreach (Int32 PostId in PostIds)
            //{
            //    AllowedPages.Add(new RobotsItem(Url.Action("ViewPost", "Blog", new { PostId = PostId }), RobotsItem.AccessTypeEnum.Allow, RobotsItem.UserAgentEnum.All));
            //}

            return AllowedPages;
        } // end get allowed robots txt items

        /// <summary>
        /// Gets the pages that are disallowed for all user agents
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        private List<RobotsItem> GetDisallowedItems(UrlHelper Url)
        {
            List<RobotsItem> DisallowedPages = new List<RobotsItem>();
            DisallowedPages.Add(new RobotsItem("/signalr", RobotsItem.AccessTypeEnum.Disallow, RobotsItem.UserAgentEnum.All));
            return DisallowedPages;
        } // end get disallowed items

        /// <summary>
        /// Gets items that are allowed only for google but not other user agents
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        private List<RobotsItem> GetGoogleOnlyPages(UrlHelper Url)
        {
            List<RobotsItem> GoogleOnlyRobots = new List<RobotsItem>();
            GoogleOnlyRobots.Add(new RobotsItem("/mygooglestaticpage.htm", RobotsItem.AccessTypeEnum.Allow, RobotsItem.UserAgentEnum.GoogleBot));
            GoogleOnlyRobots.Add(new RobotsItem("/mygooglestaticpage.htm", RobotsItem.AccessTypeEnum.Disallow, RobotsItem.UserAgentEnum.All));
            return GoogleOnlyRobots;
        } // end get google only pages
    } // end class
} // end namespace