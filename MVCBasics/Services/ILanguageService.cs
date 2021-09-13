using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Services
{
    public interface ILanguageService
    {
        Language Add(CreateLanguageViewModel language);
        PersonLanguage AddToPerson(int LID, int PID);
        LanguageViewModel All();
        LanguageViewModel FindBy(LanguageViewModel Search);
        Language FindBy(int ID);
        Language Edit(int ID, Language person);
        bool Remove(int ID);
    }
}
