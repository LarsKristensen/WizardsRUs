using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WizardsRUs.Models;

namespace WizardsRUs.Controllers
{
    public class AuthWizardController : Controller
    {

        public AuthThing AuthOrder
        {
            get
            {
                if (Session["authorder"] == null)
                    Session["authorder"] = new AuthThing();
                return (AuthThing)Session["authorder"];
            }
            set
            {
                Session["authorder"] = value;
            }
        }

        [Authorize]
        public ActionResult Step1()
        {
            HomeController.AddRequest(Session.SessionID, "/authwizard/step1___");
            return View(this.AuthOrder);
        }

        
        //[ValidateAntiForgeryToken()]
        [Authorize]
        [HttpPost]
        public ActionResult Step2(AuthThing at)
        {
            if (!string.IsNullOrEmpty(at.Text))
            {
                this.AuthOrder.Text = at.Text;
                HomeController.AddRequest(Session.SessionID, "/authwizard/step_2__");
                return View(this.AuthOrder);
            }
            else
            {
                return Redirect("/authwizard/step1");
            }
        }

        //[ValidateAntiForgeryToken()]
        [Authorize]
        [HttpPost]
        public ActionResult Step3(AuthThing at)
        {
            this.AuthOrder.Checkbox = at.Checkbox;
            HomeController.AddRequest(Session.SessionID, "/authwizard/step__3_");
            return View(this.AuthOrder);
        }

        //[ValidateAntiForgeryToken()]
        [Authorize]
        [HttpPost]
        public ActionResult Step4(AuthThing at)
        {
            this.AuthOrder.Radio = at.Radio;
            this.AuthOrder.ExtraCheckbox = at.ExtraCheckbox;
            HomeController.AddRequest(Session.SessionID, "/authwizard/step___4");
            return View(this.AuthOrder);
        }

        //[ValidateAntiForgeryToken()]
        [Authorize]
        [HttpPost]
        public ActionResult Confirm(AuthThing at)
        {
            if (Session["ordered"] == null)
                Session["ordered"] = new List<IWizardThing>();

            List<IWizardThing> Ordered = (List<IWizardThing>)Session["ordered"];
            Ordered.Add(this.AuthOrder);
            Session["ordered"] = Ordered;
            HomeController.AddRequest(Session.SessionID, "/authwizard/confirm");
            this.AuthOrder = null;

            return Redirect("~");
        }

    }
}
