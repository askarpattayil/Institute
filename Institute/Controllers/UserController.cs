using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Institute.Models;
using PasswordSecurity;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Institute.Controllers
{
    public class UserController : Controller
    {
        DB_INSTITUTION_MANAGEMENTEntities entity = new DB_INSTITUTION_MANAGEMENTEntities();
        string path;
        // GET: User
        public ActionResult Login()
        {
            
            return View();
            
        }
        public ActionResult Institute()
        {

            return View();

        }

        [HttpPost]
        public string InstituteInsert(InstitutionMaster data, FormCollection fc, HttpPostedFileBase file)
        {

            var allowedExtensions = new[] {
                ".Jpg", ".png", ".jpg", "jpeg"
            };

            var fileName = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)  
            var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  
            if (allowedExtensions.Contains(ext)) //check what type of extension  
            {
                //string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                // store the file inside ~/project folder(Img)  
                path = Path.Combine(Server.MapPath("~/Images/") + file.FileName);
                file.SaveAs(path);


            }

            System.Data.Entity.Core.Objects.ObjectParameter msg = new System.Data.Entity.Core.Objects.ObjectParameter("msg", typeof(string));
            if (ModelState.IsValid)
            {
                entity.InstitutionMaster_CURD(data.InstitutionName, data.Phone, data.Email, data.Website, data.Area, data.Address1, data.Address2, data.Address3, data.Building, data.Room, data.TRN,path, data.ShortName, "Insert", msg);

                return "0";
            }

            return "-1";
       
        }

        [HttpPost]
        public ActionResult Login(UserMaster data)

        {
            bool isPasswordCorrect = false;
            string un = data.UserName;
            string Password = data.Password;

            {
                var user = entity.UserMasters.Where(u => u.UserName == un && u.OTPVerify == 1 && u.Deleted == 0).FirstOrDefault();
                if (user != null && Password != null)
                {
                    bool result = PasswordStorage.VerifyPassword(Password, user.Password);

                    if (result == true)
                    {
                       //if (Count == "1")
                        //{
                        //}
                        //User loggedInUser = new User();
                        //loggedInUser.setId(user.userID);
                        //loggedInUser.setFullName(user.firstName);
                        //loggedInUser.setUserName(user.email);
                        //loggedInUser.setCompany(Convert.ToSingle(user.companyID));
                        //loggedInUser.setAdmin(Convert.ToSingle(user.adminStatus));
                        //Session[Constants.LOGGEDIN_USER] = loggedInUser;
                        //GetBranchCount();
                        //if (BCount == "1")
                        //{
                        //    loggedInUser.setBranch(BranchID);
                        //    Session[Constants.LOGGEDIN_USER] = loggedInUser;
                        //    return "1";
                        //}
                        //else
                        //{
                        //    loggedInUser.setBranch(BranchID);
                        //    Session[Constants.LOGGEDIN_USER] = loggedInUser;
                        //    return "1";
                        //}
                        return RedirectToAction("Dashboard", "Home");

                    }
                    else
                    {
                        ViewBag.Message = String.Format("Wrong Password");
                        return View();
                    }
                }
                else
                {
                    ViewBag.Message = String.Format("UserName not Valid", data.UserName);
                    return View();

                }
            }
        }



        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserMaster data)
        {

            string otp =generateOTP();
            int otps = Convert.ToInt32(otp);



            System.Data.Entity.Core.Objects.ObjectParameter msg = new System.Data.Entity.Core.Objects.ObjectParameter("msg", typeof(string));
            if (ModelState.IsValid)
            {
                
                data.Password = PasswordStorage.CreateHash(data.Password);
                entity.UserMaster_CURD(data.UserName, data.Mobile, data.UserName, data.Password,2,1,0,"INS",0, otps, 0,data.FirstName,data.LastName, "Insert", msg);

               string output= msg.Value.ToString();
                if(output== "User already exists")
                {
                    ViewBag.Message = String.Format("{0} Already Exists",data.UserName);
                    //return RedirectToAction("Register", "User");
                    return View();

                }
                else if(output == "Data Inserted")
                {
                    sendEmail(otp, data.UserName);
                    return RedirectToAction("VerifyUser", "User",new {email= data.UserName });
                }
                else { return View(); }
                
            }
            return View();

        }

        private void sendEmail(string otp,string email)
        {
            try
            {
                
                WebMail.SmtpServer = "smtp.gmail.com";
       
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = true;
    
                WebMail.EnableSsl = true;

                WebMail.UserName = "abremiratesintl2019@gmail.com";
                WebMail.Password = "Abr_emirates2020";

                WebMail.From = "abremiratesintl2019@gmail.com";

                string bodyMessage = "<html><body>"+
                    "<span>Thank You For Registration</span>//n"+
                    "</br>"+
                    "</br>" +
                    "Your OTP :"
                    +otp+
                    "</br>"+
                    "<a href=/www.google.com/></a>"+
                    "</body>"+
                    "</html>";



                //WebMail.Send(to: obj.ToEmail, subject: obj.EmailSubject, body: obj.EMailBody, cc: obj.EmailCC, bcc: obj.EmailBCC, isBodyHtml: true);
                WebMail.Send(to: email, subject: "Registration Verification", body: bodyMessage, cc: "", bcc: "", isBodyHtml: true);
         
          
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                ViewBag.Status = "Problem while sending email, Please check details.";

            }
        }

        private string generateOTP()
        {
            string numbers = "0123456789";
            Random objrandom = new Random();
            string strrandom = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                int temp = objrandom.Next(0, numbers.Length);
                strrandom += temp;
            }
            return strrandom;
        }

        public ActionResult VerifyUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult VerifyUser(UserMaster data)
        {
            System.Data.Entity.Core.Objects.ObjectParameter RowNumber = new System.Data.Entity.Core.Objects.ObjectParameter("RowNumber", typeof(string));
            if (ModelState.IsValid)
            {
                
                entity.UserMaster_OTP_VERIFY(data.OTP,data.Email, RowNumber);

                string output = RowNumber.Value.ToString();
                if(output=="1")
                {
                    return RedirectToAction("Institute", "User");
                }
                else
                    return RedirectToAction("VerifyUser", "User", new { email = data.Email });
            }
            return View();

        }

        public ActionResult Resend()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Resend(UserMaster data)
        {
            string otp = generateOTP();
            int otps = Convert.ToInt32(otp);
            sendEmail(otp, data.Email);

            System.Data.Entity.Core.Objects.ObjectParameter msg = new System.Data.Entity.Core.Objects.ObjectParameter("msg", typeof(string));
            if (ModelState.IsValid)
            {

                entity.UserMaster_OTP_UPDATE(data.OTP, data.Email, msg);

                string output = msg.Value.ToString();
                if (output == "OTP Updated")
                {
                    return RedirectToAction("VerifyUser", "User", new { email = data.Email });
                }
                else
                {
                    ViewBag.Message = String.Format("OTP Sending Failed");
                    return View();
                }
                   
            }
            return View();
            

        }
    }
}