using System;
using System.Collections.Generic;
using System.Linq;

namespace OCS.DataAccess.Repositories
{
    public class ColorRepository : IColorRepository
    {

        public Color GetColorById(Guid id)
        {
            using (DataModel db = new DataModel())
            {
                var color = db.Colors.Where(x => x.ColorID == id).FirstOrDefault();
                return color;
            }
        }

        public Color GetColorByName(string name)
        {
            using (DataModel db = new DataModel())
            {
                var color = db.Colors.Where(x => x.ColorName == name).FirstOrDefault();
                return color;
            }
        }
        public IEnumerable<Color> GetAllColors()
        {
            using (DataModel db = new DataModel())
            {
                return db.Colors.ToList();
            }
        }

        public void SaveColor(Color color)
        {
            using (DataModel db = new DataModel())
            {
                db.Colors.Add(color);
                db.SaveChanges();
            }
        }
    }
}
