using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payement.Entities.Entities
{
    public class StatusResponse
    {
        public string statusCode { get; set; }
        public string statusDescription { get; set; }
        public string type { get; set; }
        public string paymentAmount { get; set; }
        public string paymentDate { get; set; }
        public string expirationTime { get; set; }
        public string paymentStatus { get; set; }
        public string paymentMethod { get; set; }
        public string merchantRefNumber { get; set; }
        public string referenceNumber { get; set; }
    }
}
