using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Person> People { get; set; } = new List<Person>();
    }
}
