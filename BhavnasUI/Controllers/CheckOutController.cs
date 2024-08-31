using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BhavnasUI.data;
using BhavnasUI.Models;

namespace BhavnasUI.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        public ActionResult CheckoutIndex()
        {
            BhavanasERPEntities db = new BhavanasERPEntities();
            var sum = db.tblAddtocarts.Select(a => a.Amount).Sum();
            var Shipping = db.tblAddtocarts.Select(a => a.Shipping).Sum();
            var GrandTotal = db.tblAddtocarts.Select(a => a.GrandTotal).Sum();
            var CartCount = db.tblAddtocarts.Select(a => a.Id).Count();

            ViewBag.Sum = sum;
            ViewBag.Shipping = Shipping;
            ViewBag.Total = GrandTotal;
            ViewBag.Cart = CartCount;
            return View();
        }
        public ActionResult Saveorder(CheckoutModel model)
        {
            try
            {
                return Json(new { model = (new CheckoutModel().Save(model)), JsonRequestBehavior.AllowGet });

            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult CartList()
        {
            try
            {
                return Json(new { model = (new AddtoCartModel().CartList()), JsonRequestBehavior.AllowGet });

            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}