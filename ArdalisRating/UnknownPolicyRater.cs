using ArdalisRating.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    public class UnknownPolicyRater : RaterBase
    {

        public UnknownPolicyRater(ILogger logger) : base(logger)
        {
        }
        public override decimal Rate(Policy policy)
        {
            Logger.Log("Unknown policy type");
            return 0m;
        }
    }
}
