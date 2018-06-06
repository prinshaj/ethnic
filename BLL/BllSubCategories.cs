using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BLL
{
   public class BllSubCategories
    {

       EthnicEntities _db = new EthnicEntities();
       public int CreateSubCategory(SubCategory model)
       {
           tblSubCategory cat = new tblSubCategory();
           cat.id = model.id;
           cat.categoryid = model.categoryid;
           cat.subcategory = model.subcategory;
           _db.tblSubCategories.Add(cat);
           return _db.SaveChanges();
       }
       public int UpdateSubCategory(SubCategory model)
       {
           tblSubCategory cat = _db.tblSubCategories.Where(u => u.id == model.id).FirstOrDefault();
           cat.id = model.id;
           cat.categoryid = model.categoryid;
           cat.subcategory = model.subcategory;
           return _db.SaveChanges();
       }
       public List<SubCategory> GetAllSubCategory()
       {
           List<SubCategory> lst = new List<SubCategory>();
           var temp = _db.tblSubCategories.ToList();
           foreach (var model in temp)
           {
               SubCategory cat = new SubCategory();
               cat.id = model.id;
               cat.categoryid = model.categoryid.Value;
               cat.subcategory = model.subcategory;
               lst.Add(cat);
           }
           return lst;
       }
       public int DeleteSubCategory(int id)
       {
           tblSubCategory cat = _db.tblSubCategories.Where(u => u.id == id).FirstOrDefault();
           _db.tblSubCategories.Remove(cat);
           return _db.SaveChanges();
       }
      
    }
}
