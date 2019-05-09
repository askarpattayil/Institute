using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.UI;
using System.Web.UI.WebControls;
using Institute.Models;
namespace Institute.Controllers
{
    public class InstituteController : Controller
    {
        DB_INSTITUTION_MANAGEMENTEntities entity = new DB_INSTITUTION_MANAGEMENTEntities();
        string path;
        // GET: Institute
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InstituteRegistration()
        {
            return View();
        }

    }
}