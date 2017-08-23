using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCS.MVC.Models
{
    public class ProductsPageViewModel
    {
        public FiltersViewModel FiltersViewModel { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}