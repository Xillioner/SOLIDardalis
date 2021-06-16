using ArdalisRating.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    class LifePolicyRater : RaterBase
    {

        public LifePolicyRater(ILogger logger):base(logger)
        {
        }

        public override decimal Rate(Policy policy)
        {
            Logger.Log("Rating LIFE policy...");
            Logger.Log("Validating policy.");
            if (policy.DateOfBirth == DateTime.MinValue)
            {
                Logger.Log("Life policy must include Date of Birth.");
                return 0;
            }
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                Logger.Log("Centenarians are not eligible for coverage.");
                return 0;
            }
            if (policy.Amount == 0)
            {
                Logger.Log("Life policy must include an Amount.");
                return 0;
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
                return (baseRate * 2);

            }
            else
            {
                return (baseRate);
            }
        }
    }
}
