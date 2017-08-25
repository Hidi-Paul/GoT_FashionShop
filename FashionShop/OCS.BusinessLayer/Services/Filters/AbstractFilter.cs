using OCS.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.BusinessLayer.Services.Filters
{
    public class AbstractFilter
    {
        public IEnumerable<Product> Source;
        public AbstractFilter Filter { get; set; }

        public AbstractFilter()
        {
            
        }

        public AbstractFilter(IEnumerable<Product> source, AbstractFilter otherFilter=null)
        {
            this.Source = source;
            this.Filter = otherFilter;
        }

        public virtual FilterResult Resolve()
        {
            return new FilterResult();
        }
    }
}
