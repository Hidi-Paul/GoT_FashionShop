using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.DataAccess.Repositories
{
    public interface IGenderRepository
    {
        Gender GetGenderById(Guid id);
        Gender GetGenderByName(string name);
        IEnumerable<Gender> GetAllGenders();
        void SaveGender(Gender gender);
    }
}
