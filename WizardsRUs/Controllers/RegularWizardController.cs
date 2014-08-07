using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WizardsRUs.Models;

namespace WizardsRUs.Controllers
{
    public class RegularWizardController : Controller
    {

        public RegularThing RegularOrder
        {
            get
            {
                if (Session["regularorder"] == null)
                    Session["regularorder"] = new RegularThing();
                return (RegularThing)Session["regularorder"];
            }
            set
            {
                Session["regularorder"] = value;
            }
        }

        public ActionResult Step1()
        {
            HomeController.AddRequest(Session.SessionID, "/regularwizard/step1___");
            return View(this.RegularOrder);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Step2(RegularThing rt)
        {
            if (!string.IsNullOrEmpty(rt.Text))
            {
                this.RegularOrder.Text = rt.Text;
                HomeController.AddRequest(Session.SessionID, "/regularwizard/step_2__");
                return View(this.RegularOrder);
            }
            else
            {
                return Redirect("/regularwizard/step1");
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Step3(RegularThing rt)
        {
            this.RegularOrder.Checkbox = rt.Checkbox;
            HomeController.AddRequest(Session.SessionID, "/regularwizard/step__3_");
            return View(this.RegularOrder);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Step4(RegularThing rt)
        {
            this.RegularOrder.Radio = rt.Radio;
            this.RegularOrder.ExtraCheckbox = rt.ExtraCheckbox;
            HomeController.AddRequest(Session.SessionID, "/regularwizard/step___4");
            return View(this.RegularOrder);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Confirm(RegularThing rt)
        {
            if (Session["ordered"] == null)
                Session["ordered"] = new List<IWizardThing>();

            List<IWizardThing> Ordered = (List<IWizardThing>)Session["ordered"];
            Ordered.Add(this.RegularOrder);
            Session["ordered"] = Ordered;
            HomeController.AddRequest(Session.SessionID, "/regularwizard/confirm");
            this.RegularOrder = null;

            return Redirect("~");
        }

    }
}
