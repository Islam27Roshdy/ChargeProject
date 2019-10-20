using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Payement.Entities.Entities;
using Newtonsoft.Json;
using Payement.Entities.ViewModel;

namespace BusinessLogicLayer
{
    public class CardManager: PaymentManager
    {
        public CardRequestModel cardRequestModel;
        public IConfiguration _configuration;
        public string CardToken;
       
        public CardManager(IConfiguration configuration): base(configuration)
        {
            _configuration = configuration;
         
        }

        public async Task<Status> SendChargeRequestCard(string cardNumber,
            string expiryYear, string expiryMonth, string cvv, double amount)
        {
            SetCardChargeRequestModel();
            string token= await GenerateToken(cardNumber, cvv);
            SetTokentIntoRequestModel();
            CardChargeResponse CardChargeResponse;
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.BaseAddress = new Uri("https://atfawry.fawrystaging.com//ECommerceWeb/Fawry/payments/charge");
             
                    string jsonContent = JsonConvert.SerializeObject(cardRequestModel);
                    var requestContent = new StringContent(jsonContent, System.Text.Encoding.UTF8,
                                  "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync("https://atfawry.fawrystaging.com//ECommerceWeb/Fawry/payments/charge", requestContent);
                    string responseContent = await response.Content.ReadAsStringAsync();
                    CardChargeResponse = JsonConvert.DeserializeObject<CardChargeResponse>(responseContent);
                    // ProcessChargeResponse(response);
                    CalculatePoints(amount);
                    UserStatusResponse = await InsertOrder(cardRequestModel.merchantCode, CardChargeResponse.merchantRefNumber, cardRequestModel.customerProfileId);
                }
                catch
                {
                    UserStatusResponse.StatusDescription = "Error: Cannot send request to the server please try again";
                }
              
                return UserStatusResponse;
            }
        }

        private void SetTokentIntoRequestModel()
        {
            cardRequestModel.cardToken = CardToken;
        }

        public async Task<string> GenerateToken(string cardNumber , string cvv)
        
        {
            CardTokenRequest cardTokenRequest = new  CardTokenRequest()
            {
               cardNumber= cardNumber,
               customerEmail=cardRequestModel.customerEmail,
               customerMobile=cardRequestModel.customerMobile,
               customerProfileId=cardRequestModel.customerProfileId,
               merchantCode= cardRequestModel.merchantCode, 
               cvv =cvv,
            };
            using(HttpClient client=new HttpClient())
            {
                client.BaseAddress = new Uri("https://atfawry.fawrystaging.com//ECommerceWeb/Fawry/cards/cardToken");
                string JsonContent = JsonConvert.SerializeObject(cardTokenRequest);
                HttpContent requestContent = new StringContent(JsonContent, System.Text.Encoding.UTF8,
                                  "application/json");
                HttpResponseMessage response=await client.PostAsync("https://atfawry.fawrystaging.com//ECommerceWeb/Fawry/cards/cardToken", requestContent);
                string responseContent =  await response.Content.ReadAsStringAsync();
                CardTokenResponse cardTokenResponse = (CardTokenResponse)JsonConvert.DeserializeObject(responseContent);
                CardToken = cardTokenResponse.card.token;
                return CardToken;
               
            }
        }

        public void SetCardChargeRequestModel()
        {
            cardRequestModel = new CardRequestModel()
            {
               
                amount = (double)PaidAmount,
                merchantCode = _configuration.GetSection("CustomerSettings").GetSection("merchantCode").Value,
                description = _configuration.GetSection("CustomerSettings").GetSection("description").Value,
                customerMobile = _configuration.GetSection("CustomerSettings").GetSection("customerMobile").Value,
                customerProfileId = _configuration.GetSection("CustomerSettings").GetSection("customerProfileId").Value,
                customerEmail = _configuration.GetSection("CustomerSettings").GetSection("customerEmail").Value,
                paymentMethod ="CARD", //_configuration.GetSection("CustomerSettings").GetSection("paymentMethod").Value,
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
            cardRequestModel.signature = GenerateSignature();
        }

        public string GenerateSignature()
        {
            string signatureString = cardRequestModel.merchantCode + cardRequestModel.merchantRefNum
                + cardRequestModel.customerProfileId + cardRequestModel.paymentMethod
                + cardRequestModel.amount + cardRequestModel.cardToken + _configuration.GetSection("CustomerSettings").GetSection("secureKey");

            string shaSignature = base.GenerateSignature(signatureString);
            return shaSignature;
        }
    }
}
