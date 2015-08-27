using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myHomeWork.Models;
using myHomeWork.Service;

namespace myHomeWork.Controllers
{
    public class ForumController : Controller
    {
        ForumList data = new ForumList();
        // GET: Forum
        public ActionResult Index()
        {
            return View(data.GetData());
        }

        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string f_title)
        {
            data.DBCreate(f_title);

            return RedirectToAction("Index");
        }
    }
}