using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Institute.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BatchAllocation()
        {
            return View();
        }
        public ActionResult YearAllocation()
        {
            return View();
        }
    }
}