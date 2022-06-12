using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonContactInfo.Application.IntegrationModels
{
    public class LocationBasedReportIntegrationDto
    {
        public string Location { get; set; }
        public long PersonCount { get; set; }
        public long PhoneCount { get; set; }
    }
}
