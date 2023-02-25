using System.Collections.Generic;

namespace PeopleDB.Models.CheckList
{
    public class CheckListQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<Keyword> Keywords { get; set; }
        public string acknowledge { get; set; }
        public bool IsNew { get; set; }
        public bool IsDeleted { get; set; }
    }
}
