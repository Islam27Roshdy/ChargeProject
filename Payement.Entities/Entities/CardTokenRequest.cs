using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payement.Entities.Entities
{
    public class CardTokenRequest
    {
        public string merchantCode { get; set; }
        public string customerProfileId { get; set; }
        public string customerMobile { get; set; }
        public string customerEmail { get; set; }
        public string cardNumber { get; set; }
        public string expiryYear { get; set; }
        public string expiryMonth { get; set; }
        public string cvv { get; set; }


    }
}
