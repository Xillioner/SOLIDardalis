using System;

namespace ArdalisRating
{
    internal class RatingFactory
    {
        public RatingFactory()
        {
        }

        public Rater Create(Policy policy, RatingEngine engine)
        {
            switch (policy.Type)
            {
                case PolicyType.Life:
                    return new LifePolicyRater(engine);

                case PolicyType.Land:
                    return new LandPolicyRater(engine);
                case PolicyType.Auto:
                    return new AutoPolicyRater(engine);
                default:
                    return new UnknownPolicyRater(engine);
            }
        }
    }
}