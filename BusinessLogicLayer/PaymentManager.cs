using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Payement.Entities.Entities;
using Payement.Entities.ViewModel;

namespace BusinessLogicLayer
{
    public class PaymentManager
    {
        
        private readonly string ApiUrl = "https://atfawry.fawrystaging.com//ECommerceWeb/Fawry/payments/charge ";
        protected Status UserStatusResponse;//final status that the user will see showing Points and result of the charge(Paid,Unpaid,Expired,....)
        protected double PaidAmount;
        private double Points;
        StatusResponse FawrychargeStatus;
        protected readonly string SecureKey;
        protected readonly double PointValue=10;

        public PaymentManager(IConfiguration configuration)
        {
            SecureKey = configuration.GetSection("secureKey").Value;
            double.TryParse(configuration.GetSection("secureKey").Value,out PointValue);
        }
        public void ProcessChargeResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
             //   ChargeResultModel.IsChargeCompletedSuccessfuly = true;
            }
            else
            {
              //  ChargeResultModel.IsChargeCompletedSuccessfuly = false;
            }
        }

        public void CalculatePoints(double amount)
        {
            Points =  ( amount / PointValue);
        }
    
        public async Task<Status> InsertOrder(string merchantCode
                                   , string merchantrefNumber, string customerId)
        {
            StatusResponse FawrychargeStatus = await CheckStatus(merchantCode, merchantrefNumber);

            ChargeOrder order = new ChargeOrder()
            {
                Amount = FawrychargeStatus.paymentAmount,
                CustomerID = customerId,
                MercchantRefrenceNumber = FawrychargeStatus.merchantRefNumber,
                MerchatCode = merchantCode,
                PaymentStatus = FawrychargeStatus.paymentStatus,
                Points = Points
            };
            //Add order into database.
             return new Status() { StatusResponseObject = FawrychargeStatus, Points = Points };
        }
        public async Task UpdateOrders()
        {
            //come from the database.// call db.orders.tolist()
            List<ChargeOrder> orders = new List<ChargeOrder>();
            //
            foreach(ChargeOrder order in orders)
            {
                StatusResponse statusResponse =await CheckStatus(order.MerchatCode, order.MercchantRefrenceNumber);
                // UpdateOrder(statusResponse,order); 
            }
        }
        public async Task<StatusResponse> CheckStatus(string merchantCode
                                     , string merchantrefNumber)
       {
            string signature = sha256_hash(merchantCode + merchantrefNumber + "4d319c2aa0db4815a9b656fafac31b96");
            FawrychargeStatus = new StatusResponse();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://atfawry.fawrystaging.com//ECommerceWeb/Fawry/payments/status?merchantCode="
                   + merchantCode + "&merchantRefNumber=" + merchantrefNumber + "&signature=" + signature);
                string Urls = "https://atfawry.fawrystaging.com//ECommerceWeb/Fawry/payments/status?merchantCode="
                + merchantCode + "&merchantRefNumber=" + merchantrefNumber + "&signature=" + signature;
                try
                {
                    HttpResponseMessage ChargeStatus = await client.GetAsync(Urls);
                    string FinalStatusJson = await ChargeStatus.Content.ReadAsStringAsync();
                    if (ChargeStatus.IsSuccessStatusCode)
                    {
                        FawrychargeStatus = JsonConvert.DeserializeObject<StatusResponse>(FinalStatusJson);
                    }
                }
                catch
                {
                    FawrychargeStatus.statusDescription = "Cannot Get Charge Status to this Order";
                    // here the set Status wth Fail
                }
                return FawrychargeStatus;
            }

        }

      
        public string GenerateSignature(string sign)
        {
            return sha256_hash(sign);
        }

        public string sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}














