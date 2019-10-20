using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payement.Entities.Entities
{
    public abstract class ChargeResponse
    {
        public string referenceNumber { get; set; }
        public string merchantRefNumber { get; set; }
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public string type { get; set; }
    }
}
