using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.DataAccess.Repositories
{
    public class GenderRepository : IGenderRepository
    {

        public Gender GetGenderById(Guid id)
        {
            using (DataModel db = new DataModel())
            {
                var gender = db.Genders.Where(x => x.GenderID == id).FirstOrDefault();
                return gender;
            }
        }

        public Gender GetGenderByName(string name)
        {
            using (DataModel db = new DataModel())
            {
                var gender = db.Genders.Where(x => x.GenderName == name).FirstOrDefault();
                return gender;
            }
        }
        public IEnumerable<Gender> GetAllGenders()
        {
            using (DataModel db = new DataModel())
            {
                return db.Genders.ToList();
            }
        }

        public void SaveGender(Gender gender)
        {
            using (DataModel db = new DataModel())
            {
                db.Genders.Add(gender);
                db.SaveChanges();
            }
        }
    }
}
