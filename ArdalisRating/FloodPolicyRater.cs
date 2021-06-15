namespace ArdalisRating
{
    internal class FloodPolicyRater : Rater
    {
        private RatingEngine engine;

        public FloodPolicyRater(RatingEngine engine) : base(engine)
        {
            this.engine = engine;
        }

        public override void Rate(Policy policy)
        {
            Log("Rating FLOOD policy...");
            Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                Log("Flood policy must specify Bond Amount and Valuation.");
                return;
            }
            if (policy.EvaluationAboveSeaLevelFeet <= 0)
            {
                Log("Flood policy is not available for elevations at or below sea level.");
                return;
            }
            if (policy.BondAmount<0.8m*policy.Valuation)
            {
                Log("Insufficient bond amount.");
                return;
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
            engine.Rating = policy.BondAmount * 0.005m * multiple;
        }
    }
}