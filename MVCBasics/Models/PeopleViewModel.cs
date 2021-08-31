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
            Model = new CreatePersonViewModel();
        }
        public List<Person> people = new List<Person>();
        CreatePersonViewModel model;
        public CreatePersonViewModel Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }
        public int ID
        {
            get
            {
                return Model.ID;
            }
            set
            {
                Model.ID = value;
            }
        }
        public string Name
        {
            get
            {
                return Model.Name;
            }
            set
            {
                Model.Name = value;
            }
        }
        public int PhoneNumber
        {
            get
            {
                return Model.PhoneNumber;
            }
            set
            {
                Model.PhoneNumber = value;
            }
        }
        public string city
        {
            get
            {
                return Model.city;
            }
            set
            {
                Model.city = value;
            }
        }
    }
}
