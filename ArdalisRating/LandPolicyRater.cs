using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    class LandPolicyRater : Rater
    {
        private RatingEngine engine;

        public LandPolicyRater(RatingEngine engine) : base(engine)
        {
            this.engine = engine;
        }

        public override void Rate(Policy policy)
        {
            Log("Rating LAND policy...");
            Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                Log("Land policy must specify Bond Amount and Valuation.");
                return;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                Log("Insufficient bond amount.");
                return;
            }
            engine.Rating = policy.BondAmount * 0.05m;
        }
    }
}
