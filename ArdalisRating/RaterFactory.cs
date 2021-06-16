using ArdalisRating.Interfaces;
using System;

namespace ArdalisRating
{
    public class RaterFactory
    {
        public ILogger Logger { get; set; }

        public RaterFactory(ILogger logger)
        {
            this.Logger = logger;
        }

        public RaterBase Create(Policy policy,IRatingContext context)
        {
            try
            {
                return (RaterBase)Activator.CreateInstance(Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"), new object[] { Logger });
            }
            catch (Exception)
            {
                return new UnknownPolicyRater(Logger);
            }

            //switch (policy.Type)
            //{
            //    case PolicyType.Life:
            //        return new LifePolicyRater(ratingUpdater);

            //    case PolicyType.Land:
            //        return new LandPolicyRater(ratingUpdater);
            //    case PolicyType.Auto:
            //        return new AutoPolicyRater(ratingUpdater);
            //    case PolicyType.Flood:
            //        return new FloodPolicyRater(ratingUpdater);
            //    default:
            //        return new UnknownPolicyRater(ratingUpdater);
            //}

        }
    }
}