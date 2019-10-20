using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Payement.Entities.Entities;
using Payement.Entities.ViewModel;

namespace BusinessLogicLayer
{
    public class PayAtFawryManager: PaymentManager
    {

        private RequestModel PayAtFawryChargeRequest;
        private IConfiguration _configuration;
        private ChargeResultModel ChargeResultModel;
    
        public PayAtFawryManager(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
            ChargeResultModel = new ChargeResultModel();

        }
        public async Task<Status> SendChargeRequestPayAtFawry(double amount)
        {

            PaidAmount = Math.Round(amount, 2, MidpointRounding.ToEven);
           
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.BaseAddress = new Uri("https://atfawry.fawrystaging.com//ECommerceWeb/Fawry/payments/charge");
                    GetConfiguration();
                    string jsonContent = JsonConvert.SerializeObject(PayAtFawryChargeRequest);

                    var requestContent = new StringContent(jsonContent, System.Text.Encoding.UTF8,
                                  "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync("https://atfawry.fawrystaging.com//ECommerceWeb/Fawry/payments/charge", requestContent);
                    string responseContent = await response.Content.ReadAsStringAsync();
                    PayAtFawryChargeResponse res = await GetChargeResponse(responseContent);
                    CalculatePoints(amount);
                    UserStatusResponse = await InsertOrder(PayAtFawryChargeRequest.merchantCode, PayAtFawryChargeRequest.merchantRefNum,PayAtFawryChargeRequest.customerProfileId);
                }
                catch
                {
                    UserStatusResponse.StatusDescription = "Error: Cannot send request to the server please try again";
                }
              
                return UserStatusResponse;
            }
        }

        public void GetConfiguration()
        {
            PayAtFawryChargeRequest = new RequestModel()
            {
                amount = PaidAmount,
                
                merchantCode = _configuration.GetSection("CustomerSettings").GetSection("merchantCode").Value,
                description = _configuration.GetSection("CustomerSettings").GetSection("description").Value,
                customerMobile = _configuration.GetSection("CustomerSettings").GetSection("customerMobile").Value,
                customerProfileId = _configuration.GetSection("CustomerSettings").GetSection("customerProfileId").Value,
                customerEmail = _configuration.GetSection("CustomerSettings").GetSection("customerEmail").Value,
                paymentMethod = _configuration.GetSection("CustomerSettings").GetSection("paymentMethod").Value,
                currencyCode = _configuration.GetSection("CustomerSettings").GetSection("currencyCode").Value,
                merchantRefNum = _configuration.GetSection("CustomerSettings").GetSection("merchantRefNum").Value,
                paymentExpiry = _configuration.GetSection("CustomerSettings").GetSection("paymentExpiry").Value,
           
                chargeItems = new List<chargeItem>(){
         new chargeItem() {
         itemId= _configuration.GetSection("CustomerSettings").GetSection("chargeItems").GetSection("itemId").Value,
         description=_configuration.GetSection("CustomerSettings").GetSection("chargeItems").GetSection("description").Value,
         price=20.50,//_configuration.GetSection("CustomerSettings").GetSection("chargeItems").GetSection("price").Value,
         quantity=1// _configuration.GetSection("CustomerSettings").GetSection("chargeItems").GetSection("quantity").Value
        }
                }
            };
            PayAtFawryChargeRequest.signature = GenerateSignature();
        }

        public string GenerateSignature()
        {
            string signatureString = PayAtFawryChargeRequest.merchantCode + PayAtFawryChargeRequest.merchantRefNum
                + PayAtFawryChargeRequest.customerProfileId + PayAtFawryChargeRequest.paymentMethod
                + PayAtFawryChargeRequest.amount+".00"+ "4d319c2aa0db4815a9b656fafac31b96";//secureKey.

            string shaSignature= base.GenerateSignature(signatureString);

           // shaSignature = "27665A5052504DC0E6E006B0F919E0D7DEB54D143083905C16322F52E4BFC5F1";
            return shaSignature;
        }
        public async Task<PayAtFawryChargeResponse> GetChargeResponse(string responseContent)
        {
            PayAtFawryChargeResponse payAtFawryChargeResponse=new PayAtFawryChargeResponse();
            try
            {
               // responseContent = "{\"type\":\"ChargeResponse\",\"referenceNumber\":\"928943097\",\"merchantRefNumber\":\"99900642091\",\"expirationTime\":1516,\"statusCode\":200,\"statusDescription\":\"Operation done successfully\"}";
                payAtFawryChargeResponse = JsonConvert.DeserializeObject<PayAtFawryChargeResponse> (responseContent);
            }
            catch
            {
                payAtFawryChargeResponse.statusDescription = "Error Parsing Json";
            }
            return payAtFawryChargeResponse;
        } 
    }
}
