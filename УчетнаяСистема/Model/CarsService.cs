using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетнаяСистема.Model
{
   public class CarsService
    {
        private static List<Cars> ObjCars;
        public CarsService()
        {
            ObjCars = new List<Cars>();
        }

        public List<Cars> GetAll()
        {
            return ObjCars;
        }

        public bool Add(Cars objNewCars)
        {
            ObjCars.Add(objNewCars);
            return true;
        }
    }
}
