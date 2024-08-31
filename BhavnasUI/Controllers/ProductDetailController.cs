using Antlr.Runtime.Tree;
using BhavnasUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;

namespace BhavnasUI.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        public ActionResult ProductDetailIndex(int Id)
        {
            string add = null; 
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                     add = ip.ToString();
                }
            }
            ViewBag.ProductId = Id;
            ViewBag.CustomerId = add;
            return View();
        }

        public ActionResult ListByProductID(int Id)
        {
            try
            {
                return Json(new { model = (new ProductModel().ProductDetailsList(Id)), JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
         

        }

    }
}