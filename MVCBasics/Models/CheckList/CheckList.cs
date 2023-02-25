using System.Collections.Generic;

namespace PeopleDB.Models.CheckList
{
    public class CheckList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public CheckListParam CheckListParam { get; set; }
        public List<CheckListQuestion> CheckListQuestions { get; set; }
    }
}
