using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesTech.Controllers
{
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

        [HttpPost]
        public PartialViewResult _ParContactFormSave(FormCollection values)
        {
            string strCaptcha = HttpContext.Session["captchastring"].ToString();

            if(strCaptcha == values["txtCaptcha"])
            {
                string strBody = "Message from : " + values["txtName"] + " [" + values["txtEmail"] + "]\n\n" + values["txtMessage"];
                MailEngine.SendContactUsMessage(values["txtSubject"], strBody);
                return PartialView("../Home/_ParContactMessagePost");
            }
            else
            {
                return PartialView("../Home/_ParContactMessageWrongCaptcha");
            }
        }

        [AllowAnonymous]
        public CaptchaImageResult ShowCaptchaImage()
        {
            return new CaptchaImageResult();
        }
    }
}