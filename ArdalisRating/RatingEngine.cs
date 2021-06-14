using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine:ArdalisRatingBase
    {
        public decimal Rating { get; set; }
        public void Rate()
        {
            Logger("Starting rate.");
            Logger("Loading policy.");

            // load policy - open file policy.json
            string policyJson = GetPolicyJson();
            Policy policy = GetPolicy(policyJson);

            var rater = new RatingFactory().Create(policy, this);
            rater.Rate(policy);
            
            

            Logger("Rating completed.");
        }

    }
}
