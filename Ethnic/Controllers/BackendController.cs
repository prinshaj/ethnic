using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BO;

namespace Ethnic.Controllers
{
    public class BackendController : Controller
    {
        BLLCategory cat = new BLLCategory();
        BllSubCategories sub = new BllSubCategories();
        BLLProductManagement pro = new BLLProductManagement();
        BLLSliderImage sld = new BLLSliderImage();
        public ActionResult Index()
        {
            return View();
        }
    [HttpGet]
        public ActionResult CreateCategories()
        {

            return View();
        }
    [HttpPost]
    public ActionResult CreateCategories(Category model)
    {
       var a= cat.CreateCategory(model);
       if (a > 0)
       {
           ViewBag.Message = "Category Created";
       }
        return View(model);
    }
        [HttpGet]
    public ActionResult CreateSubCategories()
    {

        ViewBag.Name = cat.GetAllCategory();

        return View();
    }
        [HttpPost]
        public ActionResult CreateSubCategories(SubCategory model)
        {
            ViewBag.Name = cat.GetAllCategory();
            var ae = sub.CreateSubCategory(model);
            if (ae > 0)
            {
                ViewBag.Message = "Sub-Category Created"; 
            }
            return View(model);
        }

        public ActionResult GetALLSubCategories()
        {
            var ae = sub.GetAllSubCategory();
            
            return View(ae);
        }
        [HttpGet]
        public ActionResult CreateProductManagement()
        {
            ViewBag.Message = cat.GetAllCategory();
            return View();
        }
    [HttpPost]
        public ActionResult CreateProductManagement(ProductManagement model)
        {
           
            ViewBag.Message = cat.GetAllCategory();
            var b = sub.GetAllSubCategory();
            ViewBag.Messageone = new SelectList(b, "id", "subcategory");
            var i = pro.CreateProductManagement(model);
                 if (i > 0)
                    {
                         ViewBag.Message = "Product has been created";
                     }

            return View();
        }
    public JsonResult GetAllSubCategoies(int Categoryid)
    {
        var ae = sub.GetAllSubCategory().Where(u=>u.id==Categoryid).ToList();
        return Json(ae, JsonRequestBehavior.AllowGet);
    }

    [HttpGet]
    public ActionResult AddImages()
    {
        return View();
    }
    [HttpPost]
    public ActionResult AddImages(sliderImage model)
    {
        string filename = "";
        HttpPostedFileBase fup = Request.Files["ImageUpload"];
        if (fup != null)
        {
            filename = fup.FileName;
            fup.SaveAs(Server.MapPath("~/Images/" + fup.FileName));
        }
        model.ImageUpload=filename;
       var a = sld.CreateImage(model);
       if (a > 0)
       {
           ViewBag.Message = "Images Uploaded";
       }
        return View();
    }

         
	}
}