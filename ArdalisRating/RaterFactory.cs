using System;

namespace ArdalisRating
{
    internal class RaterFactory
    {
        public RaterFactory()
        {
        }

        public Rater Create(Policy policy, RatingEngine engine)
        {
            //try
            //{
            //    return (Rater)Activator.CreateInstance(Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"), new object[] { engine });
            //}
            //catch (Exception)
            //{

            //    return null;
            //}

            switch (policy.Type)
            {
                case PolicyType.Life:
                    return new LifePolicyRater(engine);

                case PolicyType.Land:
                    return new LandPolicyRater(engine);
                case PolicyType.Auto:
                    return new AutoPolicyRater(engine);
                case PolicyType.Flood:
                    return new FloodPolicyRater(engine);
                default:
                    return new UnknownPolicyRater(engine);
            }

        }
    }
}