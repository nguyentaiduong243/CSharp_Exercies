using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelMV.Service
{
    public class LocationService
    {
        public List<string> ListPlace()
        {
            return new List<string>{
                "Bac Giang",

                "Ha Noi",

                "TP HCM"

            };
        }
    }
}
