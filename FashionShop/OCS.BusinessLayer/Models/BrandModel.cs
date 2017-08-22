using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.BusinessLayer.Models
{
    public class BrandModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Category Name is mandatory")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
