using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    class AutoPolicyRater : Rater
    {
        private RatingEngine engine;

        public AutoPolicyRater(RatingEngine engine):base(engine)
        {
            this.engine = engine;
        }
        public override void Rate(Policy policy)
        {
            Log("Rating AUTO policy...");
            Log("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                Log("Auto policy must specify Make");
                return;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    engine.Rating = 1000m;
                }
                engine.Rating = 900m;
            }
        }
    }
}
