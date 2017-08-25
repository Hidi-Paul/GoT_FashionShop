using OCS.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.BusinessLayer.Services.Filters
{
    public class FilterResult
    {
        public Dictionary<string, IEnumerable<Product>> Filters;
        
        public FilterResult()
        {
            Filters = new Dictionary<string, IEnumerable<Product>>();
        }
        public void AddFilter(string key, IEnumerable<Product> values)
        {
            if (Filters.ContainsKey(key))
            {
                Filters[key]=Filters[key].Union(values);
            }
            else
            {
                Filters.Add(key, values);
            }
        }

        public IEnumerable<Product> Result()
        {
            IEnumerable<Product> Final = Filters.ElementAt(0).Value;
            for(int i = 1; i < Filters.Count; i++)
            {
                Final = Final.Intersect(Filters.ElementAt(i).Value);
            }

            return Final;
        }
    }
}
