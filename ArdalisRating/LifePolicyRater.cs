using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    class LifePolicyRater : Rater
    {
        private RatingEngine engine;

        public LifePolicyRater(RatingEngine engine):base(engine)
        {
            this.engine = engine;
        }

        public override void Rate(Policy policy)
        {
            Log("Rating LIFE policy...");
            Log("Validating policy.");
            if (policy.DateOfBirth == DateTime.MinValue)
            {
                Log("Life policy must include Date of Birth.");
                return;
            }
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                Log("Centenarians are not eligible for coverage.");
                return;
            }
            if (policy.Amount == 0)
            {
                Log("Life policy must include an Amount.");
                return;
            }
            int age = DateTime.Today.Year - policy.DateOfBirth.Year;
            if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < policy.DateOfBirth.Day ||
                DateTime.Today.Month < policy.DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = policy.Amount * age / 200;
            if (policy.IsSmoker)
            {
                engine.Rating = baseRate * 2;

            }
            else
            {
                engine.Rating = baseRate;
            }
        }
    }
}
