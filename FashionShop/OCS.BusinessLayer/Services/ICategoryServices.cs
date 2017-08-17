using OCS.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.BusinessLayer.Services
{
    public interface ICategoryServices
    {
        IEnumerable<CategoryModel> GetAll();
    }
}
