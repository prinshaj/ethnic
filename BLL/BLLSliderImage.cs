using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BLL
{
    public class BLLSliderImage
    {
        EthnicEntities _db = new EthnicEntities();
        public int CreateImage(sliderImage model){
            tblSliderImage img = new tblSliderImage();
            img.id = model.id;
            img.ImageUpload = model.ImageUpload;
            _db.tblSliderImages.Add(img);
            return _db.SaveChanges();

        }
        public int UpdateImage(sliderImage model)
        {
            tblSliderImage img = _db.tblSliderImages.Where(u => u.id == model.id).FirstOrDefault();
            img.id = model.id;
            img.ImageUpload = model.ImageUpload;
            return _db.SaveChanges();
        }

        public List<sliderImage> GetAllSliderImage()
        {
            List<sliderImage> lst = new List<sliderImage>();

            var temp = _db.tblSliderImages.ToList();
            foreach (var model in temp)
            {
              sliderImage img = new sliderImage();
                img.id = model.id;
                img.ImageUpload = model.ImageUpload; 
            }
            return lst;
        }

        public int DeleteSliderImage(int id)
        {
            tblSliderImage img = _db.tblSliderImages.Where(u => u.id == id).FirstOrDefault();
            _db.tblSliderImages.Remove(img);
            return _db.SaveChanges();
        }
       
    }
}
