using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OCS.MVC.Models
{
    public class ProductViewModel
    {
        public string ProductName { get; set; }
        
        public double ProductPrice { get; set; }
        
        public string Brand { get; set; }
        
        public string Image { get; set; }
    }
}