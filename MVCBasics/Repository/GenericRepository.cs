using MVCBasics.Repository;
using PeopleDB.Models.CheckList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleDB.Repository
{
    public class GenericRepository<T>:PeopleContext where T : class
    {
        //PeopleContext _DBContext;
        //public GenericRepository(PeopleContext _DB)
        //{
        //    this._DBContext = _DB;
        //}
        public IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var result = Set<T>();
            if (predicate != null)
            {
                var collection = result.Where<T>(predicate);
                return collection;
            }
            return null;
        }
        public virtual IEnumerable<T> GetAll()
        {
            var collection = Set<T>();
            return collection;
        }
        public void Save(T data)
        {
            Set<T>().Add(data);
            SaveChanges();
        }
    }
}
