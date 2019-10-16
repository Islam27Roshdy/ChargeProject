using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using System.Text;

namespace Payment.BusinessLogicLayer
{
    internal class PaymentManager
    {
        private readonly string Url="https://atfawry.fawrystaging.com//ECommerceWeb/Fawry/payments/charge"
         
        public async Task<int> SendRequest()
        {
            //using (var client= new HttpClient())
            //{
            //    var request=new object { };
            //    client.BaseAddress = new Uri(Url);
            //   // string content= new StringContent(request, Encoding.UTF8,"application/json");
            //  //  HttpResponseMessage response = await client.PostAsync(Url, request).Result;
            //    if(response.IsSuccessStatusCode)
            //    {

            //    }

            //}
            return 0;
        }
    }
}
