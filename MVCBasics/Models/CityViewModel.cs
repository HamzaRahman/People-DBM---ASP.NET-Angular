using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class CityViewModel
    {
        public List<City> Cities = new List<City>();
        public string SearchPhrase;
        public CreateCityViewModel CreateCity { get; set; }
    }
}
