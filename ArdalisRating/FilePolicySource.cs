using ArdalisRating.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    public class FilePolicySource:IPolicySource
    {
        private string file;

        public FilePolicySource()
        {
            file = "policy.json";
        }
        public string GetPolicyFromSource()
        {
            return new FileInfo(file).OpenText().ReadToEnd();
        }
    }
}
