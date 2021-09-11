using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class PeopleViewModel
    {
        public PeopleViewModel()
        {
            
        }
        public List<Person> people = new List<Person>();
        public string SearchPhrase { get; set; }
        public CreatePersonViewModel CreatePerson { get; set; }
    }
}
