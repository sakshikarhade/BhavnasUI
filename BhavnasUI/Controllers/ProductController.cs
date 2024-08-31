using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BhavnasUI.Models;

namespace BhavnasUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductIndex(int CategoryId)
        {
            ViewBag.CategoryId = CategoryId;
            return View();
        }
        public ActionResult SeeMoreProducts()
        {
            return View();
        }
        public ActionResult ProductListByID(int Id)
        {
            try
            {
                return Json(new { model = (new ProductModel().SearchEmpList(Id)), JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

    }
}