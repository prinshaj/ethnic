using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BO;
using DAL;

namespace BLL
{

    public class BLLProductManagement
    {
        EthnicEntities _db = new EthnicEntities();
        public int CreateProductManagement(ProductManagement model)
        {
            tblProductManagement cat = new tblProductManagement();
            cat.id = model.id;
            cat.categoryid = model.categoeyid;
            cat.subcategoryid = model.subcategoryid;
            cat.name = model.name;
            cat.description = model.description;
            cat.features = model.features;
            cat.price = model.price;
            cat.quality = model.quality;
            cat.code = model.code;
            _db.tblProductManagements.Add(cat);
            return _db.SaveChanges();
        }

        public int UpdateSubCategory(ProductManagement model)
        {
           tblProductManagement cat = _db.tblProductManagements.Where(u => u.id == model.id).FirstOrDefault();
            cat.id = model.id;
            cat.categoryid = model.categoeyid;
            cat.subcategoryid = model.subcategoryid;
            cat.name = model.name;
            cat.description = model.description;
            cat.features = model.features;
            cat.price = model.price;
            cat.quality = model.quality;
            cat.code = model.code;
            return _db.SaveChanges();
        }
        public List<ProductManagement> GetAllProductManagement()
        {
            List<ProductManagement> lst = new List<ProductManagement>();
            var temp = _db.tblProductManagements.ToList();
            foreach (var model in temp)
            {
                ProductManagement cat = new ProductManagement();
                
                cat.id = model.id;
                cat.categoeyid = model.categoeyid;
                cat.subcategoryid = Convert.ToInt32(model.subcategoryid);
                cat.name = model.name;
                cat.description = model.description;
                cat.features = model.features;
                cat.price = model.price;
                cat.quality = model.quality;
                cat.code = model.code;
                lst.Add(cat);
            }
            return lst;
        }
        public int DeleteSubCategory(int id)
        {
            tblProductManagement cat = _db.tblProductManagements.Where(u => u.id == id).FirstOrDefault();
            _db.tblProductManagements.Remove(cat);
            return _db.SaveChanges();
        }



    }
}
