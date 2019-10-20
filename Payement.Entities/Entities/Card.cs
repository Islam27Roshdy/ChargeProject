
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payement.Entities.Entities
{
    public class Card
    {
        public string token { get; set; }
        public long creationDate { get; set; }
        public string lastFourDigits { get; set; }
        public string brand { get; set; }

    }
}
