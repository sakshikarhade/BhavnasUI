using BhavnasUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BhavnasUI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryList()
        {
            try
            {
                return Json(new { model = (new CategoryModel().CategoryLST()), JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}