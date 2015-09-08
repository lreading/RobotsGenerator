using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsTxtGenerator
{
    public interface IRobotsGenerator
    {
        String GenerateRobots(IEnumerable<RobotsItem> Items);
    } // end irobots generator
} // end namespace
