using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Institute.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CourseMaster()
        {
            return View();
        }
        public ActionResult BatchMaster()
        {
            return View();
        }
        public ActionResult StudentCreation()
        {
            return View();
        }

    }
}