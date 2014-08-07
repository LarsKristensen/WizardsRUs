using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WizardsRUs.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private Dictionary<string, string> GetValidUsers()
        {
            Dictionary<string, string> validUsers = new Dictionary<string, string>();

            validUsers.Add("user1", "pw1");
            validUsers.Add("user2", "pw2");

            return validUsers;
        }

        private static List<string> Requests = new List<string>();

        public static void AddRequest(string sessionID, string url)
        {
            string tableRow = String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", DateTime.Now.ToString("HH:mm:ss.fff"), sessionID, url);
            HomeController.Requests.Add(tableRow);
        }

        public static List<string> GetRequests()
        {
            return Requests;
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Auth()
        {
            string reqUser = Request.Form["username"];
            string reqPw = Request.Form["password"];

            if (GetValidUsers().ContainsKey(reqUser))
            {
                if (GetValidUsers()[reqUser] == reqPw)
                {
                    FormsAuthentication.SetAuthCookie(reqUser, true);
                    return Redirect("~");
                }
            }
            return Redirect("~/Home/Login");
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("~");
        }

        public ActionResult Index()
        { 
            AddRequest(Session.SessionID, "home");
            return View();
        }

        public ActionResult Reset()
        {
            FormsAuthentication.SignOut();
            HttpCookie aCookie;
            string cookieName;
            int limit = Request.Cookies.Count;
            for (int i = 0; i < limit; i++)
            {
                cookieName = Request.Cookies[i].Name;
                aCookie = new HttpCookie(cookieName);
                aCookie.Expires = DateTime.Now.AddDays(-1); // make it expire yesterday
                Response.Cookies.Add(aCookie); // overwrite it
            }
            Session.Abandon();
            HomeController.Requests = new List<string>();
            Session["ordered"] = null;
            return Redirect("~");
        }

    }
}
