

using ArdalisRating.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;
using Xunit;

namespace ArdalisRating.Tests
{
    public class RatingEngineRate
    {
        private FakeLogger logger;
        private FakePolicySource policySource;
        private readonly FakePolicySerializer policySerializer;
        private RatingEngine engine;

        public RatingEngineRate()
        {
            this.logger = new FakeLogger();
            this.policySource = new FakePolicySource();
            this.policySerializer= new FakePolicySerializer();
            this.engine = new RatingEngine(logger,policySource, policySerializer,new RaterFactory(logger));
        }

        [Fact]
public void ReturnsRatingOf10000For200000LandPolicy()
{
    var policy = new Policy
    {
        Type = PolicyType.Land,
        BondAmount = 200000,
        Valuation = 200000
    };
    string json = JsonConvert.SerializeObject(policy);
            policySource.PolicyString = json;

    
    engine.Rate();
    var result = engine.Rating;

    Assert.Equal(10000, result);
}

        [Fact]
        public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };
            string json = JsonConvert.SerializeObject(policy);
            policySource.PolicyString = json;

            
            engine.Rate();
            var result = engine.Rating;

            Assert.Equal(0, result);
        }
        [Fact]
        public void LogsStartingLoadingAndCompleting()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };
            string json = JsonConvert.SerializeObject(policy);
            policySource.PolicyString = json;
            this.engine.Rate();
            var result = this.engine.Rating;

            Assert.Contains(this.logger.LoggedMessages, m => m == "Starting rate.");
            Assert.Contains(this.logger.LoggedMessages, m => m == "Loading policy.");
            Assert.Contains(this.logger.LoggedMessages, m => m == "Starting rate.");
        }
    }
}
