using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    public class UnknownPolicyRater : Rater
    {
        private RatingEngine engine;

        public UnknownPolicyRater(RatingEngine engine) : base(engine)
        {
            this.engine = engine;
        }
        public override void Rate(Policy policy)
        {
            Log("Unknown policy type");
        }
    }
}
