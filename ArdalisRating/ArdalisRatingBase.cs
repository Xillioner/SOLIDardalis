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
            policyJson = new FilePolicySource().GetPolicyJson();
            logger = new Logger();
        }

        public void Logger(string message)
        {
            logger.Log(message);
        }
        public string GetPolicyJson()
        {
            return policyJson;
        }
    }
}