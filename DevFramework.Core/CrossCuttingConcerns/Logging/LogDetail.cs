using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string Fullname { get; set; } //Namespace.Class
        public string MethodName { get; set; } //Method()
        public List<LogParameter> LogParameters { get; set; }

    }
}
