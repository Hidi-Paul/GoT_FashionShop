using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCS.MVC.Models
{
    public class FiltersModel
    {
        public string SearchString { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
        public IEnumerable<BrandModel> Brands { get; set; }
    }
}