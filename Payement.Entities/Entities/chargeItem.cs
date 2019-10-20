using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payement.Entities.Entities
{
    public class chargeItem
    {
        public string itemId { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public double quantity { get; set; }
    }
}
