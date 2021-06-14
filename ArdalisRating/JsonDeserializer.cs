using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ArdalisRating
{
    internal class JsonDeserializer
    {
        private string policyJson;

        public JsonDeserializer(string policyJson)
        {
            this.policyJson = policyJson;
        }

        public Policy GetPolicy()
        {
            return JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());
        }
    }
}