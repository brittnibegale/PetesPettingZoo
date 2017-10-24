namespace PetesPettingZoo.Controllers
{
    public class Stripe
    {
        public ActionResult Index()
        {
            var stripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            ViewBag.StripePublishKey = stripePublishKey;
            return View();
        }
    }
}