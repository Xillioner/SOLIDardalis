using ArdalisRating.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    class LandPolicyRater : RaterBase
    {

        public LandPolicyRater(ILogger logger) : base(logger)
        {
        }

        public override decimal Rate(Policy policy)
        {
            Logger.Log("Rating LAND policy...");
            Logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                Logger.Log("Land policy must specify Bond Amount and Valuation.");
                return 0;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                Logger.Log("Insufficient bond amount.");
                return 0;
            }
            return (policy.BondAmount * 0.05m);
        }
    }
}
