using OCS.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.BusinessLayer.Services.Filters
{
    public class CategoryFilter : AbstractFilter
    {
        public string CategName { get; set; }

        public CategoryFilter(IEnumerable<Product> source, string categName, AbstractFilter otherFilter = null) 
            : base(source, otherFilter)
        {
            this.CategName = categName;
        }

        public override FilterResult Resolve()
        {
            FilterResult results = (Filter != null) ? Filter.Resolve() : new FilterResult();
            var filtered = Source.Where(prod => prod.Category.CategoryName.Equals(CategName)).ToList();

            results.AddFilter("Category", filtered.ToList());
            return results;
        }
    }
}
