using OCS.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.BusinessLayer.Services.Filters
{
    public class NameSearchStringFilter : AbstractFilter
    {
        public string Name { get; set; }

        public NameSearchStringFilter(IEnumerable<Product> source, string name, AbstractFilter otherFilter = null) 
            : base(source, otherFilter)
        {
            this.Name = name.ToUpper();
        }

        public override FilterResult Resolve()
        {
            FilterResult results = (Filter != null) ? Filter.Resolve() : new FilterResult();
            var filtered = Source.Where(prod => prod.ProductName.ToUpper().Contains(Name)).ToList();

            results.AddFilter("Name", filtered);
            return results;
        }
    }
}
