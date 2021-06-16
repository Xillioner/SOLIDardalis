using ArdalisRating.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ArdalisRating
{
    internal class JsonPolicySerializer:IPolicySerializer
    {
        private Policy policy;

        public JsonPolicySerializer()
        {
            policy = new Policy();
        }

        public Policy GetPolicyFromString(string policyJson)
        {
            try
            {
                return JsonConvert.DeserializeObject<Policy>(policyJson,
                    new StringEnumConverter());
            }
            catch
            {
                policy.Type = PolicyType.Unknown;
                return policy;
            }
        }
    }
}