using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.DataAccess.Repositories
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(Guid id);
        Category GetCategoryByName(string name);
        IEnumerable<Category> GetAllCategories();

        void SaveCategory(Category categ);
    }
}
