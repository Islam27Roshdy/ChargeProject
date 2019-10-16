using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payement.Entities.Entities
{
    //ChargeRequestModel
    public class RequestModel
    {
 
        public string merchantCode { get; set; }
        public string merchantRefNum { get; set; }
        public string customerProfileId { get; set; }
        public string customerMobile { get; set; }
        public string customerEmail { get; set; }
        public string paymentMethod { get; set; }
        public double amount { get; set; }
        public string currencyCode { get; set; }
        public string description { get; set; }
        public string paymentExpiry { get; set; }
        public List<chargeItem> chargeItems { get; set; }
        public string signature { get; set; }


    //{ "merchantCode":"is0N+YQzlE4=", "merchantRefNum":"9990064204",
    //"customerProfileId":"9990064204", "customerMobile":"01000000200", 
    //"customerEmail":"77@test.com", "paymentMethod":"PAYATFAWRY", "amount":20.10, 
    //"currencyCode":"EGP", "description":"the charge request description",
    //"paymentExpiry":1516554874077, 
    //"chargeItems":[ { "itemId":"897fa8e81be26df25db592e81c31c", 
    //    "description":"asdasd", "price":15.20, "quantity":1 } ], 
    //"signature":"fc82831bcd928d22337e9eace61d30c75d6fc027f59f0be571f90ab2231967fa" }
    }
}
