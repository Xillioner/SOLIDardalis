using System;
using System.IO;

namespace ArdalisRating
{
    public abstract class ArdalisRatingBase
    {
        private string policyJson;

        public ArdalisRatingBase()
        {
            this.policyJson = new FilePolicySource().GetPolicyJson();
        }

        public string GetPolicyJson()
        {
            return policyJson;
        }

        public Policy GetPolicy(string policyJson)
        {
            return new JsonDeserializer(policyJson).GetPolicy();
        }
    }
}