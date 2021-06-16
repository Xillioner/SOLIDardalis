using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating.Interfaces
{
    public interface IRatingContext:ILogger
    {
        RatingEngine Engine { get; set; }


        RaterBase CreateRaterForPolicy(Policy policy, IRatingContext context);

        Policy GetPolicyFromXmlString(string policyXml);

        Policy GetPolicyFromJsonString(string policyJson);

        string LoadPolicyFromURI(string uri);
        string LoadPolicyFromFile();
    }
}
