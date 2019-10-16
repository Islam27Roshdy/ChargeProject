using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Payement.Entities.Entities;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace BusinessLogicLayer
{
    public class PaymentManager
    {

        IConfiguration _configuration;
        private RequestModel RequestModel;
        private readonly string ApiUrl = "https://atfawry.fawrystaging.com//ECommerceWeb/Fawry/payments/charge ";
        private ChargeResultModel ChargeResultModel;
        private double PaidAmount;
        public PaymentManager(IConfiguration configuration)
        {
            _configuration = configuration;
            ChargeResultModel = new ChargeResultModel();

        }
        public async Task<ChargeResultModel> SendPaymentRequest(double amount)
        {
            PaidAmount = amount;
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.BaseAddress = new Uri("https://atfawry.fawrystaging.com//ECommerceWeb/Fawry/payments/charge");
                    GetConfiguration();
                    string jsonContent = JsonConvert.SerializeObject(RequestModel);

                    var requestContent = new StringContent(jsonContent, Encoding.UTF8,
                                  "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync("https://atfawry.fawrystaging.com//ECommerceWeb/Fawry/payments/charge", requestContent);
                    ProcessChargeResponse(response);

                }
                catch
                {
                    ChargeResultModel.IsChargeCompletedSuccessfuly = false;  
                }
                CalculatePoints();
                return ChargeResultModel;
            }
        }
        public void GetConfiguration()
        {
            RequestModel = new RequestModel()
            {
                    amount=PaidAmount,
                    merchantCode = _configuration.GetSection("CustomerSettings").GetSection("merchantCode").Value,

                    customerMobile = _configuration.GetSection("CustomerSettings").GetSection("customerMobile").Value,
                    customerProfileId = _configuration.GetSection("CustomerSettings").GetSection("customerProfileId").Value,
                    customerEmail = _configuration.GetSection("CustomerSettings").GetSection("customerEmail").Value,
                    paymentMethod = _configuration.GetSection("CustomerSettings").GetSection("paymentMethod").Value,
                    currencyCode = _configuration.GetSection("CustomerSettings").GetSection("currencyCode").Value,
                    merchantRefNum = _configuration.GetSection("CustomerSettings").GetSection("merchantRefNum").Value,
                    paymentExpiry = _configuration.GetSection("CustomerSettings").GetSection("paymentExpiry").Value,
                    signature = _configuration.GetSection("CustomerSettings").GetSection("signature").Value,

                chargeItems = new List<chargeItem>(){
         new chargeItem() {
         itemId= _configuration.GetSection("CustomerSettings").GetSection("chargeItems").GetSection("itemId").Value,
         description=_configuration.GetSection("CustomerSettings").GetSection("chargeItems").GetSection("description").Value,
         price=20.50,//_configuration.GetSection("CustomerSettings").GetSection("chargeItems").GetSection("price").Value,
         quantity=1// _configuration.GetSection("CustomerSettings").GetSection("chargeItems").GetSection("quantity").Value
        }
                }
            };
        }

        public void ProcessChargeResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                ChargeResultModel.IsChargeCompletedSuccessfuly = true;
            }
            else
            {
                ChargeResultModel.IsChargeCompletedSuccessfuly = false;
            }
        }

        public void CalculatePoints()
        {
          ChargeResultModel.Points = RequestModel.amount / 10;
          ChargeResultModel.CustomerID = RequestModel.customerProfileId;
        }
 
    }
}
        
         





//signature ="974703AB6E3BD7114BAD0B42F11C5C84615DB97B6FA48D5E9CB03E5183F6EF91",
//                amount =20.10,
//                chargeItems= new List<chargeItem>()
//                {
//                    new chargeItem{itemId="897fa8e81be26df25db592e81c31c", description="asdasd", price=20.40, quantity=1}
//                },
//                description="the charge request description",
//                currencyCode="EGP",
//                customerEmail="developer794@gmail.com",
//                customerMobile="01092730313",
//                customerProfileId="9990064204",
//                 merchantCode="uQ8ETgA45xY=",
//                 merchantRefNum="9990064204",
//                  paymentExpiry=1516554874077,
//                  paymentMethod="PAYATFAWRY"