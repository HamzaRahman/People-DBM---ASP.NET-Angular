using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class CreateCityViewModel
    {
        public CreateCityViewModel()
        {

        }
        City _Model;
        public City Model
        {
            get
            {
                return _Model;
            }
            set
            {
                _Model = Model;
            }
        }
    }
}
