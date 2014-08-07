using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WizardsRUs.Models;
using System.Web.Helpers.AntiXsrf;
using System.Web.Helpers;

namespace WizardsRUs.Controllers
{
    public class ACSRFWizardController : Controller
    {
        public ACSRFThing ACSRFOrder
        {
            get
            {
                if (Session["acsrforder"] == null)
                    Session["acsrforder"] = new ACSRFThing();
                return (ACSRFThing)Session["acsrforder"];
            }
            set
            {
                Session["acsrforder"] = value;
            }
        }

        public ActionResult Step1()
        {
            HomeController.AddRequest(Session.SessionID, "/acsrfwizard/step1___");
            return View(this.ACSRFOrder);
        }

        [ValidateAntiForgeryToken()]
        [HttpPost]
        public ActionResult Step2(ACSRFThing act)
        {
            if (!string.IsNullOrEmpty(act.Text))
            {
                this.ACSRFOrder.Text = act.Text;
                HomeController.AddRequest(Session.SessionID, "/acsrfwizard/step_2__");
                return View(this.ACSRFOrder);
            }
            else
            {
                return Redirect("/acsrfwizard/step1");
            }
        }

        [ValidateAntiForgeryToken()]
        [HttpPost]
        public ActionResult Step3(ACSRFThing act)
        {
            this.ACSRFOrder.Checkbox = act.Checkbox;
            HomeController.AddRequest(Session.SessionID, "/acsrfwizard/step__3_");
            return View(this.ACSRFOrder);
        }

        [ValidateAntiForgeryToken()]
        [HttpPost]
        public ActionResult Step4(ACSRFThing act)
        {
            this.ACSRFOrder.Radio = act.Radio;
            this.ACSRFOrder.ExtraCheckbox = act.ExtraCheckbox;
            HomeController.AddRequest(Session.SessionID, "/acsrfwizard/step___4");
            return View(this.ACSRFOrder);
        }

        [ValidateAntiForgeryToken()]
        [HttpPost]
        public ActionResult Confirm(ACSRFThing act)
        {
            if (Session["ordered"] == null)
                Session["ordered"] = new List<IWizardThing>();

            List<IWizardThing> Ordered = (List<IWizardThing>)Session["ordered"];
            Ordered.Add(this.ACSRFOrder);
            Session["ordered"] = Ordered;
            HomeController.AddRequest(Session.SessionID, "/acsrfwizard/confirm");
            this.ACSRFOrder = null;

            return Redirect("~");
        }
    }
}
