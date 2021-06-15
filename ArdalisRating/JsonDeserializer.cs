using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ArdalisRating
{
    internal class JsonDeserializer:ArdalisRatingBase
    {
        private string policyJson;
        private Policy policy;

        public JsonDeserializer(string policyJson)
        {
            this.policyJson = policyJson;
            policy = new Policy();
        }

        public Policy GetPolicy()
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