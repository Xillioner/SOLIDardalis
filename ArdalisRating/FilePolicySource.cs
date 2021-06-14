using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    class FilePolicySource
    {
        private string file;

        public FilePolicySource()
        {
            file = "policy.json";
        }
        public string GetPolicyJson()
        {
            return new FileInfo(file).OpenText().ReadToEnd();
        }
    }
}
