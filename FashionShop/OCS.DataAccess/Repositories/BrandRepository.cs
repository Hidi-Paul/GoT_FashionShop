using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.DataAccess.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        public Brand GetBrandById(Guid id)
        {
            using(DataModel db=new DataModel())
            {
                var brand = db.Brands.Where(x => x.BrandID == id).First();
                return brand;
            }
        }
        public Brand GetBrandByName(string name)
        {
            using(DataModel db=new DataModel())
            {
                var brand = db.Brands.Where(x => x.BrandName == name).First();
                return brand;
            }
        }
        public IEnumerable<Brand> GetAllBrands()
        {
            using(DataModel db=new DataModel())
            {
                return db.Brands.ToList();
            }
        }
        public void SaveBrand(Brand brand)
        {
            using(DataModel db=new DataModel())
            {
                db.Brands.Add(brand);
                db.SaveChanges();
            }
        }
    }
}
