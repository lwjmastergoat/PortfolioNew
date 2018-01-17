using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;
using System.Web.Security;
using System.Web.Helpers;

namespace PortfolioNew.Controllers
{

    public class HomeController : Controller
    {

        AccountTableFac bf = new AccountTableFac();
        MainTableFac mtf = new MainTableFac();
        PortfolioTableFactory ptf = new PortfolioTableFactory();
        MainTable mt = new MainTable();
        UserCodingTableFac uctf = new UserCodingTableFac();
        MainOptions mo = new MainOptions();
        UserInformationTableFac uitf = new UserInformationTableFac();
        UserGraphicsTableFac ugtf = new UserGraphicsTableFac();



        // GET: Home
        public ActionResult Index()
        {

            MainOptions PortfolioStats = new MainOptions();
            PortfolioStats.MainTables = mtf.GetAllJoin();
            PortfolioStats.Portfolio = ptf.GetAllJoin();

            return View(PortfolioStats);
        }

        
        [HttpGet]
        public ActionResult GetAllJoin()
        {
            MainOptions SiteStats = new MainOptions();
            
            SiteStats.Portfolio = ptf.GetAllJoin();
            SiteStats.UserCoding = uctf.GetAllJoin();
            SiteStats.UserGraphics = ugtf.GetAllJoin();
            SiteStats.UserInformation = uitf.GetAllJoin();
            SiteStats.MainTables = mtf.GetAllJoin();
            return Json(SiteStats, JsonRequestBehavior.AllowGet);
        }


        Mailer mailer = new Mailer("smtp.gmail.com", "email@gmail.com", "DitNavne", "email@gmail.com", "password", 587);

        public ActionResult SendMail(string Subject, string BodyText)
        {
            mailer.Send(Subject, BodyText, "kontakt@lassewormark.com");

            ViewBag.MSG = "Mailen er sendt!!!";

            return View("/Home/Index");
        }

        public ActionResult Details(int ID)
        {
            if (ID != 0)
            {
                try
                {
                    return View(ptf.GetDetails(ID));
                }
                catch
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return Redirect("/Home/Index/");
            }
        }

        public ActionResult Details2(int ID)
        {
            if (ID != 0)
            {
                try
                {
                    return View(ptf.GetDetails(ID));
                }
                catch
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return Redirect("/Home/Index/");
            }
        }

        [Authorize]

        public ActionResult Edit(int ID)
        {
            
            

            return View(ptf.GetDetails(ID));

        }


        [HttpPost]

        public ActionResult Edit(PortfolioTable input)
        {
            ptf.Updates(input);

            return Redirect("/Home/Details/" + input.ID);
        }

        [Authorize]

        public ActionResult Edit2()
        {
            return View(mtf.GetAllJoin());
        }

        [HttpPost]

        public ActionResult Edit2(MainTable input)
        {
            mtf.Updates(input);

            return Redirect("/Home/Index");
        }









        // BRUGER LOGIN

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult LoginResult()
        {
            string email = Request["Email"].Trim();
            string password = /*Crypto.Hash(*/Request["Password"].Trim()/*)*/;

            AccountTable b = bf.Login(email, password);

            if (b.ID > 0)
            {
                FormsAuthentication.SetAuthCookie(b.ID.ToString(), false);
                Session["UserID"] = b.ID;
                Session["UserName"] = b.Name;
                Session["Type"] = b.Type;
                Session.Timeout = 120;

                if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                {
                    Response.Redirect(Request.QueryString["ReturnUrl"]);
                }

                return Redirect("/Home/Secret");
            }
            else
            {
                ViewBag.MSG = "Brugeren blev ikke fundet";

                return View("Login");
            }
        }


        [Authorize]
        public ActionResult Secret()
        {
            MainOptions PortfolioStats = new MainOptions();
            PortfolioStats.MainTables = mtf.GetAllJoin();
            PortfolioStats.Portfolio = ptf.GetAllJoin();
            PortfolioStats.UserCoding = uctf.GetAllJoin();
            PortfolioStats.UserGraphics = ugtf.GetAllJoin();
            PortfolioStats.UserInformation = uitf.GetAllJoin();

            return View(PortfolioStats);
        }

        public ActionResult LogUd()
        {
            FormsAuthentication.SignOut();
            Session.Contents.RemoveAll();
            return RedirectToAction("AccountTable", "Login");
        }


        [Authorize]

        public ActionResult Edit3(int ID)
        {


            return View(uctf.GetByID(ID));
        }

        [HttpPost]

        public ActionResult Edit3(UserCodingTable input)
        {

            uctf.Update(input);

            return Redirect("/Home/Index");
        }

        [Authorize]

        public ActionResult Edit4(int ID)
        {


            return View(ugtf.GetByID(ID));
        }

        [HttpPost]

        public ActionResult Edit4(UserGraphicsTable input)
        {

            ugtf.Update(input);

            return Redirect("/Home/Index");
        }

        [Authorize]

        public ActionResult Edit5(int ID)
        {


            return View(uitf.GetByID(ID));
        }

        [HttpPost]

        public ActionResult Edit5(UserInformationTable input)
        {

            uitf.Update(input);

            return Redirect("/Home/Index");
        }


    }





}