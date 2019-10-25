using CruiseWeb.Models;
using CruiseWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CruiseWeb.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Send_Email()
        {
            return View(new SendEmailViewModel());
        }
/*Used to send bulk emails by the admin to all the users in the database*/
        [HttpPost]
        public ActionResult Send_Email(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;

                    EmailSender es = new EmailSender();
                    es.Send(subject, contents);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }
/*Display chart in the home controller as a bubble chart*/
        [HttpPost]
        public JsonResult AjaxMethod()
        {
            string query = "SELECT CostPerNight, Duration, CruiseDepPortName";
            query += " FROM Cruises";
            string constr = ConfigurationManager.ConnectionStrings["Rating"].ConnectionString;
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
                            {
                            "CruiseDepPortName", "CostPerNight","Duration"
                            });
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            chartData.Add(new object[]
                            {
                            sdr["CruiseDepPortName"],sdr["CostPerNight"],sdr["Duration"]
                            });
                        }
                    }

                    con.Close();
                }
            }

            return Json(chartData);
        }

    }

}
   