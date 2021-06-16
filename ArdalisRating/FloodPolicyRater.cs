using ArdalisRating.Interfaces;

namespace ArdalisRating
{
    internal class FloodPolicyRater : RaterBase
    {

        public FloodPolicyRater(ILogger logger) : base(logger)
        {
        }

        public override decimal Rate(Policy policy)
        {
            Logger.Log("Rating FLOOD policy...");
            Logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                Logger.Log("Flood policy must specify Bond Amount and Valuation.");
                return 0;
            }
            if (policy.EvaluationAboveSeaLevelFeet <= 0)
            {
                Logger.Log("Flood policy is not available for elevations at or below sea level.");
                return 0;
            }
            if (policy.BondAmount<0.8m*policy.Valuation)
            {
                Logger.Log("Insufficient bond amount.");
                return 0;
            }
            decimal multiple = 1.0m;
            if (policy.EvaluationAboveSeaLevelFeet<100)
            {
                multiple = 2.0m;
            }
            else if (policy.EvaluationAboveSeaLevelFeet < 500)
            {
                multiple = 1.5m;
            }
            else if (policy.EvaluationAboveSeaLevelFeet < 1000)
            {
                multiple = 1.1m;
            }
            return (policy.BondAmount * 0.005m * multiple);
        }
    }
}