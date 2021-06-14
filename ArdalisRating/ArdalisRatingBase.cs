using System;
using System.IO;

namespace ArdalisRating
{
    public abstract class ArdalisRatingBase
    {
        private string policyJson;
        private Logger logger;

        public ArdalisRatingBase()
        {
            this.logger = new Logger();
            this.policyJson = new FilePolicySource().GetPolicyJson();
        }

        public void Logger(string message)
        {
            logger.Log(message);
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