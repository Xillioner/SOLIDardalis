using Ardalis.GuardClauses;
using ArdalisRating.Interfaces;
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
    public class RatingEngine
    {
        private ILogger logger;
        private IPolicySource policySource;
        private IPolicySerializer policySerializer;
        private readonly RaterFactory raterFactory;

        public IRatingContext Context { get; set; }
        public decimal Rating { get; set; }
        public RatingEngine(ILogger logger,IPolicySource policySource,IPolicySerializer policySerializer, RaterFactory raterFactory)
        {
            this.logger = logger;
            this.policySource = policySource;
            this.policySerializer = policySerializer;
            this.raterFactory = raterFactory;

        }
        public void Rate()
        {
            logger.Log("Starting rate.");
            logger.Log("Loading policy.");

            // load policy - open file policy.json
            string policyJson = policySource.GetPolicyFromSource();
            Policy policy = policySerializer.GetPolicyFromString(policyJson);

            var rater = raterFactory.Create(policy, Context);
            Rating = rater.Rate(policy);
            logger.Log("Rating completed.");
        }

        
    }
}
