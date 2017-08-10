using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.DataAccess.Repositories
{
    public interface IBrandRepository
    {
        Brand GetBrandById(Guid id);
        Brand GetBrandByName(string name);
        IEnumerable<Brand> GetAllBrands();

        void SaveBrand(Brand brand);
    }
}
