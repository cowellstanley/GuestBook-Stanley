using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myHomeWork.Models;
using myHomeWork.Service;

namespace myHomeWork.Controllers
{
    public class ActicleController : Controller
    {
        ForumList data = new ForumList();
        // GET: Acticle
        public ActionResult Index()
        {
            return View(data.GetAData(Request["F_ID"]));
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View(data.GetAEData(Request["A_ID"]));
        }

        [HttpPost]
        public ActionResult Create(string a_title, string a_body, string a_author, string F_ID)
        {
            data.ADBCreate(a_title, a_body, a_author, F_ID);

            var url = "/Acticle/Index?F_ID=" + F_ID;
            return Redirect(url);
            
        }

        [HttpPost]
        public ActionResult Edit(string a_title, string a_body, string a_author, string F_ID, string A_ID)
        {
            data.AEDBCreate(a_title, a_body, a_author, F_ID, A_ID);

            var url = "/Acticle/Index?F_ID=" + F_ID + "&A_ID=" + A_ID;
            return Redirect(url);

        }
    }
}