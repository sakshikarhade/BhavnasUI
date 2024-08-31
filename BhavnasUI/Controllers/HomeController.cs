using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

using System.Web.Mvc;
using System.Net.Sockets;


namespace BhavnasUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()// homepage index made by Saurabh Sambhe 
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    string add = ip.ToString();
                }
            }
                return View();
                throw new Exception("No network adapters with an IPv4 address in the system!");
           
        }
       
        public ActionResult HomeIndex()// homepage index made by Nishid Jojare
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}