using ArdalisRating.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ArdalisRating.Tests
{
    internal class FakePolicySerializer:IPolicySerializer
    {
        private readonly Policy policy;

        public FakePolicySerializer()
        {
            this.policy = new Policy();

        }

        public Policy GetPolicyFromString(string policyJson)
        {
            try
            {
                return JsonConvert.DeserializeObject<Policy>(policyJson,
                    new StringEnumConverter());
            }
            catch (Exception)
            {
                policy.Type = PolicyType.Unknown;
                return policy;

            }
        }
    }
}