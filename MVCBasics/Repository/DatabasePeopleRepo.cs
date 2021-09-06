using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Repository
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        PeopleContext _DB;
        public DatabasePeopleRepo(PeopleContext _DB)
        {
            this._DB = _DB;
        }
        public Person Create(string Name, int PhoneNumber, string City)
        {
            Person p = new Person();
            p.Name = Name;
            p.PhoneNumber = PhoneNumber;
            p.city = City;
            _DB.People.Add(p);
            _DB.SaveChanges();
            return p;
        }

        public bool Delete(Person person)
        {
            if(_DB.People.Contains(person))
            {
                _DB.People.Remove(person);
                return true;
            }
            return false;
        }

        public List<Person> Read()
        {
            return _DB.People.AsParallel().ToList();
        }

        public Person Read(int ID)
        {
            return _DB.People.Where(person => person.ID == ID).FirstOrDefault();
        }

        public Person Update(Person person)
        {
            var ToBeUpdate = _DB.People.FirstOrDefault(p => p.ID == person.ID);
            if (ToBeUpdate != null)
            {
                _DB.Entry(ToBeUpdate).CurrentValues.SetValues(person);
            }
            return person;
        }
    }
}
