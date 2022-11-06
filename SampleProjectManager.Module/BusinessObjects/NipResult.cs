using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectManager.Module.BusinessObjects
{


        public class ResponseDto
        {
            public Result result { get; set; }
        }

        public class Result
        {
            public Subject subject { get; set; }
            public string requestId { get; set; }
            public string requestDateTime { get; set; }
        }

        public class Subject
        {
            public string name { get; set; }
            public string nip { get; set; }
            public string statusVat { get; set; }
            public string regon { get; set; }
            public string pesel { get; set; }
            public string krs { get; set; }
            public string residenceAddress { get; set; }
            public string workingAddress { get; set; }
            public string[] representatives { get; set; }
            public string[] authorizedClerks { get; set; }
            public string[] partners { get; set; }
            public string registrationLegalDate { get; set; }
            public string registrationDenialBasis { get; set; }
            public string registrationDenialDate { get; set; }
            public string restorationBasis { get; set; }
            public string restorationDate { get; set; }
            public string removalBasis { get; set; }
            public string removalDate { get; set; }
            public string[] accountNumbers { get; set; }
            public bool hasVirtualAccounts { get; set; }
        }

   
}
