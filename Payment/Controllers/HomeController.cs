using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using Payment.Models;
using Microsoft.Extensions.Configuration;
using Payement.Entities.Entities;
using Newtonsoft.Json;
namespace Payment.Controllers
{
    public class HomeController : Controller
    {
        private readonly PaymentManager _paymentManager;
        //private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration): base()
        {
            _paymentManager = new PaymentManager(configuration);
          
            
        } 
        public async Task<IActionResult> Index()
        {
            
           return View();
        }

        public IActionResult Charge()
        {
            return View();
        }

        public JsonResult ChargeProcess(double amount)
        {
            var responseObject = _paymentManager.SendPaymentRequest(amount).Result;
           return Json( JsonConvert.SerializeObject(responseObject));
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
