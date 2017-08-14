using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {


        public Category GetCategoryById(Guid id)
        {
            using (DataModel db = new DataModel())
            {
                var categ = db.Categories.Where(x => x.CategoryID == id).FirstOrDefault();
                return categ;
            }
        }

        public Category GetCategoryByName(string name)
        {
            using (DataModel db = new DataModel())
            {
                var categ = db.Categories.Where(x => x.CategoryName == name).FirstOrDefault();
                return categ;
            }
        }
        public IEnumerable<Category> GetAllCategories()
        {
            using (DataModel db = new DataModel())
            {
                return db.Categories.ToList();
            }
        }
        public void SaveCategory(Category categ)
        {
            using (DataModel db = new DataModel())
            {
                db.Categories.Add(categ);
                db.SaveChanges();
            }
        }
    }
}
