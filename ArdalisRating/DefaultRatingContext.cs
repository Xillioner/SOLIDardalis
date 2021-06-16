using ArdalisRating.Interfaces;

namespace ArdalisRating
{
    internal class DefaultRatingContext : IRatingContext
    {
        private readonly IPolicySource policySource;

        public DefaultRatingContext(IPolicySource policySource, IPolicySerializer policySerializer)
        {
            this.policySource = policySource;
        }

        public RatingEngine Engine { get; set; }

        public RaterBase CreateRaterForPolicy(Policy policy, IRatingContext context)
        {
            return context.CreateRaterForPolicy(policy, context);
        }

        public Policy GetPolicyFromJsonString(string policyJson)
        {
            return new JsonPolicySerializer().GetPolicyFromString(policyJson);
        }

        public Policy GetPolicyFromXmlString(string policyXml)
        {
            throw new System.NotImplementedException();
        }

        public string LoadPolicyFromFile()
        {
            return this.policySource.GetPolicyFromSource();
        }

        public string LoadPolicyFromURI(string uri)
        {
            throw new System.NotImplementedException();
        }

        public void Log(string message)
        {
            new ConsoleLogger().Log(message); 
        }

    }
}   