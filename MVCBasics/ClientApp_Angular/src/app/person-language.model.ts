import { Person } from "./person.model";
import { Language } from "./language.model";
export class PersonLanguage
{
  constructor(
    public id: number,
    public personID: number,
    public person: Person,
    public languageID: number,
    public language: Language) {

  }
}
