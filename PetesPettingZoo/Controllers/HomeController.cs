//using Stripe;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace PetesPettingZoo.Controllers
//{
//    public class HomeController : Controller
//    {
//        public ActionResult Index()
//        {
//            return View();
//        }

//        public ActionResult Map()
//        {
//            return View();
//        }

//        public ActionResult About()
//        {
//            ViewBag.Message = "Your application description page.";

//            return View();
//        }

//        public ActionResult Contact()
//        {
//            ViewBag.Message = "Your contact page.";

//            return View();
//        }

//        public IActionResult Charge(string stripeEmail, string stripeToken)
//        {
//            var customers = new StripeCustomerService();
//            var charges = new StripeChargeService();

//            var customer = customers.Create(new StripeCustomerCreateOptions
//            {
//                Email = stripeEmail,
//                SourceToken = stripeToken
//            });

//            var charge = charges.Create(new StripeChargeCreateOptions
//            {
//                //Amount = TicketCost,
//                Description = "Ticket Cost",
//                Currency = "$",
//                CustomerId = customer.Id
//            });

//            //return View();
//        }
//    }