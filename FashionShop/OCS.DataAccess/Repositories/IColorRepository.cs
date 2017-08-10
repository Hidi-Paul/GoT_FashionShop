using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.DataAccess.Repositories
{
    public interface IColorRepository
    {
        Color GetColorById(Guid id);
        Color GetColorByName(string name);
        IEnumerable<Color> GetAllColors();
        void SaveColor(Color color);
    }
}
