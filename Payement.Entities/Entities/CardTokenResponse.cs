using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payement.Entities.Entities
{
    public class CardTokenResponse
    {
        public string type { get; set; }
        public Card card { get; set; }
        public string statusCode { get; set; }
        public string statusDescription { get; set; }

    }

}
