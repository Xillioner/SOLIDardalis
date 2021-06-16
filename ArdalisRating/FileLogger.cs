using ArdalisRating.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            using (var stream=new FileInfo("log.txt").AppendText())
            {
                stream.WriteLine(message);
                stream.Flush();
            }
        }
    }
}
