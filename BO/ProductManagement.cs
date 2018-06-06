using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ProductManagement
    {
        public int id { get; set; }
        public int categoeyid { get; set; }
        public int subcategoryid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string features { get; set; }
        public string price { get; set; }
        public string quality { get; set; }
        public string code { get; set; }

    }
}
