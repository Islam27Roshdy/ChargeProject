using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payement.Entities.Entities
{
    public class ChargeResultModel
    {
        public bool IsChargeCompletedSuccessfuly { get; set; }
        public string CustomerID { get; set; }
        public double Points { get; set; }
    }
}
