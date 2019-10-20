using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Payement.Entities.Entities
{
    public class ChargeOrder
    {
        [Key] //this is auto generated unique number for each order 
        public string   MercchantRefrenceNumber { get; set; }
        public double Points { get; set; }
        public string MerchatCode { get; set; }
        public string CustomerID { get; set; }
        public string Amount { get; set; }
        public string PaymentStatus { get; set; }
    }
}
