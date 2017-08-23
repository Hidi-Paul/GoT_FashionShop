using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCS.MVC.Models
{
    public class FiltersViewModel
    {
        public string SearchString { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public IEnumerable<BrandViewModel> Brands { get; set; }
    }
}