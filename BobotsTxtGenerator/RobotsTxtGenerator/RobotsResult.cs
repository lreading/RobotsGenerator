using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RobotsTxtGenerator
{
    /// <summary>
    /// Generates a robots.txt file
    /// </summary>
    public class RobotsResult : ActionResult
    {
        private readonly IEnumerable<RobotsItem> _Items;
        private readonly IRobotsGenerator _Generator;

        public RobotsResult(IEnumerable<RobotsItem> Items)
            : this(Items, new RobotsGenerator())
        {
        } // end constructor

        public RobotsResult(IEnumerable<RobotsItem> Items, IRobotsGenerator Generator)
        {
            this._Items = Items;
            this._Generator = Generator;
        } // end constructor

        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase Response = context.HttpContext.Response;

            Response.ContentType = "text/plain";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            Response.Output.Write(_Generator.GenerateRobots(_Items));
        } // end execute result override
    } // end robots result
} // end namespace