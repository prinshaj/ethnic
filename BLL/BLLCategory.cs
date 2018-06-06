using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BO;

namespace BLL
{
    
   public  class BLLCategory
    {
       EthnicEntities _db = new EthnicEntities();
       public int CreateCategory(Category model)
       {
           tblCategory cat = new tblCategory();
           cat.id = model.id;
           cat.category_name = model.category_name;
           cat.status = Convert.ToBoolean(model.status);
           _db.tblCategories.Add(cat);
           return _db.SaveChanges();
       }
       public int UpdateCategory(Category model)
       {
           tblCategory cat = _db.tblCategories.Where(u => u.id == model.id).FirstOrDefault();
           cat.id = model.id;
           cat.category_name = model.category_name;
           cat.status = model.status;
           return _db.SaveChanges();
       }
       public List<Category> GetAllCategory()
       {
           List<Category> lst = new List<Category>();
           var temp = _db.tblCategories.ToList();
           foreach (var model in temp)
           {
               Category cat = new Category();
               cat.id = model.id;
               cat.category_name = model.category_name;
               cat.status = Convert.ToBoolean(model.status);
               lst.Add(cat);
           }
           return lst;
       }
       public int DeleteCategory(int id)
       {
           tblCategory cat = _db.tblCategories.Where(u => u.id == id).FirstOrDefault();
           _db.tblCategories.Remove(cat);
           return _db.SaveChanges();
       }
      

    }
}
