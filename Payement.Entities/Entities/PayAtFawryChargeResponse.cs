using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payement.Entities.Entities
{
    public class PayAtFawryChargeResponse: ChargeResponse
    {
        public long expirationTime { get; set; }
    }
}
