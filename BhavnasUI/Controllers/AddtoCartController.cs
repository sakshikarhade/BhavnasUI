using BhavnasUI.data;
using BhavnasUI.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BhavnasUI.Controllers
{
    public class AddtoCartController : Controller
    {
        // GET: AddtoCart
        public ActionResult CartIndex()
        {
            BhavanasERPEntities db = new BhavanasERPEntities();
            var sum = db.tblAddtocarts.Select(a => a.Amount).Sum();
            var Shipping = db.tblAddtocarts.Select(a => a.Shipping).Sum();
            var GrandTotal = db.tblAddtocarts.Select(a => a.GrandTotal).Sum();
            var CartCount = db.tblAddtocarts.Select(a => a.Id).Count();

            ViewBag.Sum = sum;
            ViewBag.Shipping = Shipping;
            ViewBag.Total = GrandTotal;
            @ViewBag.Cart = CartCount;
            return View();
        }
        public ActionResult SaveCart(AddtoCartModel model)
        {
            try
            {
                return Json(new { model = (new AddtoCartModel().Save(model)), JsonRequestBehavior.AllowGet });

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