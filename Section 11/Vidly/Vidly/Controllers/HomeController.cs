using GoogleRecaptcha;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PostIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostIndex(FormCollection form)
        {
            IRecaptcha<RecaptchaV2Result> recaptcha = new RecaptchaV2(new RecaptchaV2Data
            {
                Secret = "6LeIxAcTAAAAAGG-vFI1TnRWxMZNFuojJ4WifJWe"
            });

            var result = recaptcha.Verify();
            if (result.Success)
            {
                //TODO: do the thing
            }

            return View();
        }
    }
}