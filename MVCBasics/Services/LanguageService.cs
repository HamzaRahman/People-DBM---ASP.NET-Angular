using MVCBasics.Models;
using MVCBasics.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Services
{
    public class LanguageService : ILanguageService
    {
        ILanguageRepo LanguageDatabase;
        public LanguageService(ILanguageRepo _LanguageDatabase)
        {
            LanguageDatabase = _LanguageDatabase;
        }
        public Language Add(CreateLanguageViewModel language)
        {
            return LanguageDatabase.Create(language.Name);
        }
        public PersonLanguage AddToPerson(int LID,int PID)
        {
            return LanguageDatabase.AddToPerson(LID, PID);
        }
        LanguageViewModel LVM = new LanguageViewModel();
        public LanguageViewModel All()
        {
            LVM.Languages = LanguageDatabase.Read();
            return LVM;
        }

        public Language Edit(int ID, Language person)
        {
            throw new NotImplementedException();
        }

        public LanguageViewModel FindBy(LanguageViewModel Search)
        {
            throw new NotImplementedException();
        }

        public Language FindBy(int ID)
        {
            return LanguageDatabase.Read(ID);
        }

        public bool Remove(int ID)
        {
            var languages = LanguageDatabase.Read();
            var language = languages.Where(p => p.ID == ID).FirstOrDefault();
            return LanguageDatabase.Delete(language);
        }
    }
}
